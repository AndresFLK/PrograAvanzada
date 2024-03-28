namespace WEB.Models
{
    public class SaveCancelViewModel
    {
        public static SaveCancelViewModel Create(int id, string returnUrl)
        {
            return new SaveCancelViewModel
            {
                Id = id,
                ReturnUrl = returnUrl
            };
        }

        public int Id{ get; set; }
        public string ReturnUrl{ get; set; }
    }
}
