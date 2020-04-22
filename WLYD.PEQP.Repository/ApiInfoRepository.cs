using System.Data;
using System.Threading.Tasks;
using Compeng.PEQP.Model.ExpressInferceModels.ApiInfo;
using Dapper;
using System.Linq;

namespace Compeng.PEQP.Repository
{
    public class ApiInfoRepository
    {
        private readonly IDbConnection _dbConnection;
        public ApiInfoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;

        }
        public async Task<ApiInfo> GetApiInfoByCompanyCodeAsync(string code)
        {
            OpenConnection();
            string sql = "SELECT * FROM apiinfo WHERE companycode=@code";
            ApiInfo apiInfo = await _dbConnection.QueryFirstOrDefaultAsync<ApiInfo>(sql, new { code });
            if (apiInfo != null)
            {
                sql = "SELECT * FROM apiiteminfo WHERE  apiinfoid= @infoid";
                var itemList = await _dbConnection.QueryAsync<ApiItemInfo>(sql, new { infoid = apiInfo.Id });
                apiInfo.ApiItemInfoList = itemList.ToList();
            }
            _dbConnection.Close();
            return apiInfo;

        }

        public ApiInfo GetApiInfoByCompanyCode(string code)
        {
            OpenConnection();
            string sql = "SELECT * FROM apiinfo WHERE companycode=@code";
            ApiInfo apiInfo =  _dbConnection.QueryFirstOrDefault<ApiInfo>(sql, new { code });
            if (apiInfo != null)
            {
                sql = "SELECT * FROM apiiteminfo WHERE  apiinfoid= @infoid";
                var itemList = _dbConnection.Query<ApiItemInfo>(sql, new { infoid = apiInfo.Id });
                apiInfo.ApiItemInfoList = itemList.ToList();
            }
            _dbConnection.Close();
            return apiInfo;

        }

        private void OpenConnection()
        {
            if (_dbConnection.State == ConnectionState.Closed)
            {
                _dbConnection.Open();
            }
        }
    }
}
