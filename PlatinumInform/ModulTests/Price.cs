//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModulTests
{
    using System;
    using System.Collections.Generic;
    
    public partial class Price
    {
        public int NumPP { get; set; }
        public System.DateTime DateInsert { get; set; }
        public int CodeProduct { get; set; }
        public decimal Cost { get; set; }
        public int NumContract { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
