//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JAJ.WinForm
{
    using System;
    using System.Collections.Generic;
    
    public partial class PPM_ShareFile
    {
        public int ID { get; set; }
        public string SortCode { get; set; }
        public string FileName { get; set; }
        public Nullable<decimal> FileSize { get; set; }
        public string FilePath { get; set; }
        public string FileDesc { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Memo { get; set; }
    
        public virtual SYS_SortDict SYS_SortDict { get; set; }
        public virtual SYS_User SYS_User { get; set; }
    }
}