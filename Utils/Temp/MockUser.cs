using ToDoListApi.Models;

namespace ToDoListApi.Utils.Temp
{
    public static class MockUser
    {
        public static void GetUserData(this AbstractModel model)
        {
            var apiUser = "ApiUser";
            if (string.IsNullOrEmpty(model.CreatedBy))
                model.CreatedBy = apiUser;
            model.UpdatedBy = apiUser;
        }
    }
}