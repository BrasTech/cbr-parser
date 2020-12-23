using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SystemGlobalServices.Model;

namespace SystemGlobalServices.Models
{
    public class IndexViewModel
    {
        private static IndexViewModel instance;
        public CBRModel CBRModel { get; set; }

        public PageModel PageModel = new PageModel();

        public List<IDType> FilteredData { get; set; }
        public IDType FilteredDataById { get; set; }
        public bool isDefaultSearch { get; set; }
        public IndexViewModel()
        {
            RefreshData();
        }
        public static IndexViewModel getInstance()
        {
            if (instance == null)
                instance = new IndexViewModel();
            return instance;
        }
        private void RefreshData()
        {
            this.CBRModel = GetData();
            int currentPage = Constants.Page.initPage;
            int pagesForModel = (int)Math.Ceiling((double)(CBRModel.Valute.Count / Constants.Page.itemsPerPage));
            if (pagesForModel < currentPage)
                currentPage = pagesForModel;
            this.PageModel.UpdateData(CBRModel.Valute.Count, currentPage, Constants.Page.itemsPerPage);
        }
        public void FilterDataById(string Id)
        {
            isDefaultSearch = string.IsNullOrEmpty(Id);

            RefreshData();

            FilteredDataById = CBRModel.Valute.Values.FirstOrDefault(u => u.ID == Id);
        }
        public void FilterData(int page)
        {
            if (page <= PageModel.TotalPages && page > 0)
            {
                PageModel.UpdatePage(page);
                FilteredData = CBRModel.Valute.Skip((page - 1) * Constants.Page.itemsPerPage).Take(Constants.Page.itemsPerPage).Select(u => u.Value).ToList();
            }
            else FilteredData = new List<IDType>();
        }
        private CBRModel GetData()
        {
            string json = GetServerResponse();

            return JsonConvert.DeserializeObject<CBRModel>(json);
        }
        /// <summary>
        /// Получение ответа с сервера
        /// </summary>
        /// <returns></returns>
        private string GetServerResponse()
        {
            HttpClient http = new HttpClient();

            var data = http.GetAsync(Constants.URL.cbr_daily).Result.Content.ReadAsStringAsync().Result;

            return data;
        }
    }
}
