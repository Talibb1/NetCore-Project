

using Entities.ViewModel.Identity.RoleVM;
using Newtonsoft.Json;
using Service.ConsumeService.Identity.Abstract;
using System.Text;

namespace Service.ConsumeService.Identity.Concrete
{
    public class RoleConsumeService : IRoleConsumeService
    {

        private readonly HttpClient _httpClient;
        private readonly string _url;

        public RoleConsumeService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _url = "https://localhost:7051/api/Role/";
        }

        public List<RoleListVM> GetRole()
        {
            List<RoleListVM> roleList = new List<RoleListVM>();
            HttpResponseMessage response = _httpClient.GetAsync(_url + "GetRole").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<RoleListVM>>(result);

                roleList = data!;

            }
            return roleList;
        }

        public RoleListVM GetRoleById(string Id)
        {
            RoleListVM role = new RoleListVM();
            HttpResponseMessage response = _httpClient.GetAsync(_url + "GetById/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<RoleListVM>(result);

                role = data!;

            }
            return role;
        }




        public bool Create(RoleAddVM request)
        {
            request.Id = Guid.NewGuid().ToString();
            var content = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var result = _httpClient.PostAsync(_url + "Create", stringContent).Result;
            if (result.IsSuccessStatusCode) return true;
            else return false;


        }

        public bool Update(RoleUpdateVM request)
        {
            var content = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var result = _httpClient.PutAsync(_url + "Update", stringContent).Result;
            if (result.IsSuccessStatusCode) return true;
            else return false;

        }
        public bool Delete(string Id)
        {
            var result = _httpClient.DeleteAsync(_url + "Delete/" + Id).Result;
            if (result.IsSuccessStatusCode) return true;
            else return false;

        }

    }

}
