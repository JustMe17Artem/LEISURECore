//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LEISURECore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request
    {
        public int ID_Request { get; set; }
        public Nullable<int> ID_Object { get; set; }
        public string Name { get; set; }
        public Nullable<int> ID_Type_Event { get; set; }
        public Nullable<System.DateTime> Date_Start { get; set; }
        public Nullable<int> ID_Visitor { get; set; }
        public Nullable<System.DateTime> Date_End { get; set; }
        public string Contact_Phone { get; set; }
    
        public virtual Object Object { get; set; }
        public virtual Type_Event Type_Event { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
