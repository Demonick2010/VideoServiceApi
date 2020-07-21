using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace VideoService.Models.Models
{
    public static class GenericGetDataClass<TModel> where TModel : class
    {
        public static async Task<TModel> GetCategoryData(string actionPath)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                TModel categories;

                var response = await client.GetAsync(actionPath);

                if (response.IsSuccessStatusCode)
                {
                    categories = await response.Content.ReadAsAsync<TModel>();
                    return categories;
                }
                else
                    return null;
            }

        }

        public static async Task<bool> EditCategoryData(string actionPath, TModel editedModel)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PutAsJsonAsync(actionPath, editedModel);

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }

        }

        public static async Task<bool> AddCategoryData(string actionPath, TModel addedModel)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync(actionPath, addedModel);

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }

        }

        public static async Task<bool> DeleteCategory(string actionPath)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync(actionPath);

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }

        }
    }
}
