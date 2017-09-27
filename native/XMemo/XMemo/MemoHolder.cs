using System;
namespace XMemo
{
    public class MemoHolder
    {
        public static MemoHolder Current { get; } = new MemoHolder();
        public Memo Memo { get; set; }
    }
}
