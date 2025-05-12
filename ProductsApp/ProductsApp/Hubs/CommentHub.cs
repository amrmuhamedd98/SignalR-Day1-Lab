using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Data;
using ProductsApp.Models;

namespace CommentsHub.Hubs
{
    public class CommentHub : Hub
    {
        ProductsDbContext context;
        public CommentHub(ProductsDbContext _context)
        {
            context = _context;
        }
        public async Task SendComment(int productId, string username, string text)
        {
            var comment = new Comment
            {
                ProductId = productId,
                Username = username,
                Text = text
            };

            context.Comments.Add(comment);
            await context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveComment",
                productId,
                username,
                text);
        }
    }
}