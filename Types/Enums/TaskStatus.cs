using System.ComponentModel;

namespace ToDoListApi.Types.Enums{
    public enum ItemStatus{
        [Description("Pendiente")]
        Pending = 1,
        [Description("Activo")]
        Active,
        [Description("Finalizado")]
        Done,
        
    }
}