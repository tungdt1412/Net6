using Net_6.Logic.Shared.Models;
using Net_6.Ultils.Model;

namespace Net_6.Website.Models
{
    public class CommentTreeViewModel
    {
        public bool IsRoot { get; set; }
        public IEnumerable<TreeList<CommentModel>> Collection { get; set; } 
            = new List<TreeList<CommentModel>>();
    }
}
