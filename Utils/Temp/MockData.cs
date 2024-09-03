using ToDoListApi.Dtos.Models;
using ToDoListApi.Models;

namespace ToDoListApi.Utils.Temp
{
    public static class MockData
    {
        public static void GetUserData(this AbstractModel model)
        {
            var apiUser = "ApiUser";
            if (string.IsNullOrEmpty(model.CreatedBy))
                model.CreatedBy = apiUser;
            model.UpdatedBy = apiUser;
        }

        public static void FillBaseData(this AbstractModel model)
        {
            model.CreatedAt = DateTime.Now.ToUniversalTime();
            model.UpdatedAt = DateTime.Now.ToUniversalTime();
            model.GetUserData();
        }

        public static void FillBaseData(this BaseDto dto)
        {
            dto.CreatedAt = DateTime.Now.ToUniversalTime();
            dto.UpdatedAt = DateTime.Now.ToUniversalTime();

            var apiUser = "ApiUser";
            if (string.IsNullOrEmpty(dto.CreatedBy))
                dto.CreatedBy = apiUser;
            dto.UpdatedBy = apiUser;
        }

    }
}