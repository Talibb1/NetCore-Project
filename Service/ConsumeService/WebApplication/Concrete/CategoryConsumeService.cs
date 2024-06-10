

using BaseLayer.Model;
using Entities.ViewModel.PagerVM;
using Entities.ViewModel.WebApplication.CategoryVM;
using Newtonsoft.Json;
using Service.ConsumeService.WebApplication.Abstract;
using System.Text;

namespace Service.ConsumeService.WebApplication.Concrete
{
    public class CategoryConsumeService : ICategoryConsumeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;


        public CategoryConsumeService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
            _url = "https://localhost:7051/api/Category/";
        }

        public PagingVM GetCategories(int CurrentPageCount)
        {
            PagingVM pager = new PagingVM();
            HttpResponseMessage response = _httpClient.GetAsync(_url + "GetList/" + CurrentPageCount).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<PagingVM>(result);

                pager.Categories = data!.Categories!;
                pager.Paging = new PagerModel();
                pager.Paging.CurrentPageCount = data.Paging!.CurrentPageCount;
                pager.Paging.PagingCount = data.Paging.PagingCount;

            }
            return pager;
        }


        public CategoryListVM GetCategoriesById(int Id)
        {
            CategoryListVM category = new CategoryListVM();
            HttpResponseMessage response = _httpClient.GetAsync(_url + "GetById/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<CategoryListVM>(result);
                category = data!;
            }
            return category;
        }

        public AuthResultApiModel CreateCategoryAsync(CategoryAddVM request)
        {
            AuthResultApiModel model = new AuthResultApiModel();

            var content = JsonConvert.SerializeObject(request);
            StringContent jsonData = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_url + "Add", jsonData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<AuthResultApiModel>(result);

                model.Error = data.Error;
                model.Message = data.Message;
            }
            return model;
        }


        public AuthResultApiModel UpdateCategoryAsync(CategoryUpdateVM request)
        {

            AuthResultApiModel model = new AuthResultApiModel();

            var obj = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(_url + "Update/" + request.Id, content).Result;


            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<AuthResultApiModel>(result);

                model.Error = data.Error;
                model.Message = data.Message;
            }
            return model;
        }


        public AuthResultApiModel DeleteCategoryAsync(int Id)
        {
            AuthResultApiModel model = new AuthResultApiModel();

            HttpResponseMessage response = _httpClient.DeleteAsync(_url + "Delete/" + Id).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<AuthResultApiModel>(result);

                model.Error = data.Error;
                model.Message = data.Message;
            }
            return model;
        }

    }
}
