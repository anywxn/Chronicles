//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chronicles
{
    using System;
    using System.Collections.Generic;
    
    public partial class Группы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Группы()
        {
            this.Альпинисты_в_группах = new HashSet<Альпинисты_в_группах>();
            this.Восхождения = new HashSet<Восхождения>();
        }
    
        public int ID_Группы { get; set; }
        public Nullable<int> Количество { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Альпинисты_в_группах> Альпинисты_в_группах { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Восхождения> Восхождения { get; set; }
    }
}
