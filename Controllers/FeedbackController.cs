// Controllers/FeedbackController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Data;
using RestaurantSystem.Models;

namespace RestaurantSystem.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(ApplicationDbContext context, ILogger<FeedbackController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Feedback/Create
        public async Task<IActionResult> Create(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return NotFound();
            }

            ViewBag.OrderItems = order.OrderItems;
            ViewBag.OrderId = orderId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Feedback feedback, [FromForm] List<DishFeedback> dishFeedbacks)
        {
            try
            {
                var userId = HttpContext.Session.GetString("UserId");
                if (!string.IsNullOrEmpty(userId))
                {
                    feedback.UserId = int.Parse(userId);
                }

                feedback.CreatedAt = DateTime.UtcNow;
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();

                foreach (var dishFeedback in dishFeedbacks)
                {
                    if (dishFeedback.Rating > 0)
                    {
                        dishFeedback.FeedbackId = feedback.Id;
                        _context.DishFeedbacks.Add(dishFeedback);
                    }
                }
                await _context.SaveChangesAsync();

                var redirectUrl = HttpContext.Session.GetString("UserRole") == "admin"
                    ? "/Admin/AdminDashboard"
                    : "/User/UserDashboard";

                return Json(new
                {
                    success = true,
                    message = "Feedback sent successfully!",
                    redirectUrl = redirectUrl
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting feedback");
                return Json(new { success = false, message = "Error submitting feedback" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAverageRatings()
        {
            try
            {
                var ratings = await _context.Feedbacks
                    .GroupBy(f => 1)
                    .Select(g => new {
                        overallRatings = new
                        {
                            service = Math.Round(g.Average(f => f.ServiceRating), 1),
                            food = Math.Round(g.Average(f => f.FoodQualityRating), 1),
                            ambiance = Math.Round(g.Average(f => f.AmbianceRating), 1),
                            cleanliness = Math.Round(g.Average(f => f.CleanlinessRating), 1),
                            value = Math.Round(g.Average(f => f.ValueForMoneyRating), 1)
                        },
                        totalFeedbacks = g.Count()
                    })
                    .FirstOrDefaultAsync();

                if (ratings == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "No feedback data available"
                    });
                }

                return Json(new
                {
                    success = true,
                    data = ratings
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving average ratings");
                return Json(new
                {
                    success = false,
                    message = "Error retrieving ratings data"
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPopularDishes()
        {
            try
            {
                // Get popular dishes with their order counts and ratings
                var popularDishes = await _context.OrderItems
                    .GroupBy(oi => oi.MenuItem)
                    .Select(g => new
                    {
                        name = g.Key.Name,
                        orderCount = g.Sum(oi => oi.Quantity),
                        rating = _context.DishFeedbacks
                            .Where(df => df.MenuItemId == g.Key.Id)
                            .Average(df => (double?)df.Rating) ?? 0,
                        revenue = g.Sum(oi => oi.Quantity * oi.UnitPrice)
                    })
                    .OrderByDescending(x => x.orderCount)
                    .Take(5)
                    .ToListAsync();

                // Calculate category performance
                var totalOrders = await _context.OrderItems.SumAsync(oi => oi.Quantity);
                var categoryPerformance = await _context.OrderItems
                    .GroupBy(oi => oi.MenuItem.Category)
                    .Select(g => new
                    {
                        category = g.Key,
                        orders = g.Sum(oi => oi.Quantity),
                        percentage = (g.Sum(oi => oi.Quantity) * 100.0 / totalOrders)
                    })
                    .OrderByDescending(x => x.orders)
                    .ToListAsync();

                return Json(new { success = true, data = new { popularDishes, categoryPerformance } });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching popular dishes");
                return Json(new { success = false, message = "Error retrieving data" });
            }
        }
    }
}