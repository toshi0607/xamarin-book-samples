using System;
namespace XMemo
{
    public class MemoHolder
    {
        public static MemoHolder Current { get; set; }
        public Memo Memo { get; set; }
    }
}
