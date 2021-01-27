using System;
using System.Runtime.InteropServices;

using HWND = System.IntPtr;
using HANDLE = System.IntPtr;

/// <summary>
/// http://www.office-cn.net/t/api/api_content.htm
/// 
/// http://www.yfvb.com/help/win32sdk/index.htm
/// 
/// https://docs.microsoft.com/zh-cn/dotnet/api/system.runtime.interopservices?view=netframework-4.8
/// </summary>

namespace Jm.Core.Win32Api
{
    #region struct
    public struct DRAGINFO
    {
        public int uSize;
        public POINT pt;
        public int fNC;
        public string lpFileList;
        public int grfKeyState;
    }
    public struct APPBARDATA
    {
        public int cbSize;
        public HWND hwnd;
        public int uCallbackMessage;
        public int uEdge;
        public RECT rc;
        public int lParam;
    }
    public struct SHFILEOPSTRUCT
    {
        public HWND hwnd;
        public int wFunc;
        public string pFrom;
        public string pTo;
        public short fFlags;
        public int fAnyOperationsAborted;
        public HANDLE hNameMappings;
        public string lpszProgressTitle;
    }
    public struct SHNAMEMAPPING
    {
        public string pszOldPath;
        public string pszNewPath;
        public int cchOldPath;
        public int cchNewPath;
    }
    public struct SHELLEXECUTEINFO
    {
        public int cbSize;
        public int fMask;
        public HWND hwnd;
        public string lpVerb;
        public string lpFile;
        public string lpParameters;
        public string lpDirectory;
        public int nShow;
        public HANDLE hInstApp;
        public int lpIDList;
        public string lpClass;
        public HANDLE hkeyClass;
        public int dwHotKey;
        public HANDLE hIcon;
        public HANDLE hProcess;
    }
    public struct NOTIFYICONDATA
    {
        public int cbSize;
        public HWND hwnd;
        public int uID;
        public int uFlags;
        public int uCallbackMessage;
        public HANDLE hIcon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] public string szTip;
    }
    public struct SHFILEINFO
    {
        public HANDLE hIcon;
        public int iIcon;
        public int dwAttributes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Kernel32.MAX_PATH)] public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] public string szTypeName;
    }
    #endregion

    public abstract class Shell32
    {
        /// <summary>
        /// 解析一个宽字符的Unicode命令行字符串
        /// </summary>
        /// <param name="lpCmdLine">指向空终止的Unicode命令行字符串。应用程序通常会直接传递给GetCommandLineW的调用返回的值。</param>
        /// <param name="pNumArgs">指向函数设置为解析参数计数的整数变量的指针。</param>
        /// <returns>如果函数成功，则返回值是指向构造的参数列表的非空指针，该参数列表是一组Unicode宽字符参数字符串。如果函数失败，返回值为NULL。要获取扩展错误信息，请调用GetLastError.</returns>
        [DllImport("shell32")] public static extern int CommandLineToArgv(string lpCmdLine, short pNumArgs);
        [DllImport("shell32")] public static extern int DoEnvironmentSubst(string szString, int cbString);
        /// <summary>
        /// 函数检索已删除文件的文件名
        /// </summary>
        /// <param name="hDROP">标识包含已删除文件的文件名的结构</param>
        /// <param name="UINT">指定要查询的文件的索引。
        /// 如果【UINT】参数的值为0xFFFFFFFF，则DragQueryFile返回丢弃的文件计数。
        /// 如果【UINT】参数的值在零和删除的总数之间，则DragQueryFile将具有相应值的文件名复制到【lpStr】参数指向的缓冲区
        /// </param>
        /// <param name="lpStr">当函数返回时，指向缓冲区以接收丢弃文件的文件名。该文件名是一个以null结尾的字符串。如果此参数为NULL，则DragQueryFile返回缓冲区所需的大小（以字符为单位）</param>
        /// <param name="ch">文件名缓冲区大小</param>
        /// <returns></returns>
        [DllImport("shell32")] public static extern int DragQueryFile(HANDLE hDROP, int UINT, string lpStr, int ch);
        /// <summary>
        /// 在文件删除时检索鼠标指针的位置
        /// </summary>
        /// <param name="hDROP">标识描述丢弃文件的结构。</param>
        /// <param name="lpPoint">指向POINT结构，该函数在文件删除时填充鼠标指针的坐标。</param>
        /// <returns></returns>
        [DllImport("shell32")] public static extern int DragQueryPoint(HANDLE hDROP, ref POINT lpPoint);
        [DllImport("shell32")] public static extern int DuplicateIcon(HANDLE hInst, HANDLE hIcon);
        /// <summary>
        /// 可判断一个可执行程序或DLL中是否存在图标，或是否有图标与系统注册表中指定的文件存在关联。随后，它允许我们提取出那些图标
        /// </summary>
        /// <param name="hInst">当前应用程序的实例句柄。也可用GetWindowWord函数取得拥有一个窗体或控件的示例的句柄</param>
        /// <param name="lpIconPath">指定一个文件名，准备从该文件中提取图标。如果文件并非执行程序或DLL本身，但通过系统注册表与一个可执行文件关联，就用这个字串装载可执行程序的名字</param>
        /// <param name="lpiIcon">在其中装载图标在可执行文件中的资源标识符</param>
        /// <returns>如果找到任何图标，就返回图标的句柄；否则返回零</returns>
        [DllImport("shell32")] public static extern int ExtractAssociatedIcon(HANDLE hInst, string lpIconPath, ref int lpiIcon);
        /// <summary>
        /// 判断一个可执行文件或DLL中是否有图标存在，并将其提取出来
        /// </summary>
        /// <param name="hInst">当前应用程序的实例句柄。也可用GetWindowWord函数取得拥有一个窗体或控件的实例的句柄</param>
        /// <param name="lpszExeFileName">在其中提取图标的那个程序的全名</param>
        /// <param name="nIconIndex">欲获取的图标的索引。如果为-1，表示取得文件中的图标总数</param>
        /// <returns>如成功，返回指向图标的句柄；如文件中不存在图标，则返回零。如果nIconIndex设为-1，就返回文件中的图标总数</returns>
        [DllImport("shell32")] public static extern int ExtractIcon(HANDLE hInst, string lpszExeFileName, int nIconIndex);
        [DllImport("shell32")] public static extern int ExtractIconEx(string lpszFile, int nIconIndex, ref int phiconLarge, ref int phiconSmall, int nIcons);
        /// <summary>
        /// 查找与一个指定文件关联在一起的程序的文件名。可用Windows注册表编辑器将文件类型与特定的应用程序关联到一起。比如，扩展名为.TXT的文本文件通常与Windows记事本（Notepad.exe）关联到一起。如在文件管理器中双击含.TXT扩展名的一个文件，会自动启动记事本，并在其中载入文本文件
        /// </summary>
        /// <param name="lpFile">指定要为其查找相关程序的一个文件名或程序名</param>
        /// <param name="lpDirectory">要使用的默认目录的完整路径</param>
        /// <param name="lpResult">指定一个字串缓冲区，用于装载可执行程序的名字。注意这个字串预先至少都要初始化成MAX_PATH个字符的长度</param>
        /// <returns>大于32表示成功；31表示不存在文件类型的关联；0表示系统内存或资源不足；ERROR_FILE_NOT_FOUND表示指定的文件不存在；ERROR_PATH_NOT_FOUND表示指定的路径不存在；ERROR_BAD_FORMAT表示执行格式无效</returns>
        [DllImport("shell32")] public static extern int FindExecutable(string lpFile, string lpDirectory, string lpResult);
        /// <summary>
        /// 向系统发送应用程序栏消息
        /// </summary>
        /// <param name="dwMessage">
        /// 要发送的应用程序栏消息的标识符。此参数可以是以下值之一：
        /// ABM_ACTIVATE 通知系统应用程序栏已被激活。
        /// ABM_GETAUTOHIDEBAR 检索与屏幕特定边缘相关联的自动隐藏应用程序的句柄。
        /// ABM_GETSTATE 检索Windows任务栏的自动隐藏和永远在线状态。
        /// ABM_GETTASKBARPOS 检索Windows任务栏的边界矩形。
        /// ABM_NEW 注册一个新的应用程序栏，并指定系统应用于向应用程序发送通知消息的消息标识符。
        /// ABM_QUERYPOS 请求一个应用程序的大小和屏幕位置。
        /// ABM_REMOVE 取消注册应用程序栏，从系统的内部列表中删除栏。
        /// ABM_SETAUTOHIDEBAR 注册或注销屏幕边缘的自动隐藏应用栏。
        /// ABM_SETPOS 设置应用程序的大小和屏幕位置。
        /// ABM_WINDOWPOSCHANGED 当appbar的位置发生变化时通知系统。
        /// </param>
        /// <param name="pData">指向APPBARDATA结构。结构的内容取决于【dwMessage】的值。</param>
        /// <returns>返回与消息相关的值。有关详细信息，请参阅各个应用程序栏消息的文档</returns>
        [DllImport("shell32")] public static extern int SHAppBarMessage(int dwMessage, ref APPBARDATA pData);
        /// <summary>
        /// 对文件系统对象执行复制，移动，重命名或删除操作。
        /// </summary>
        /// <param name="lpFileOp">指向SHFILEOPSTRUCT结构的指针，其中包含函数执行操作的信息</param>
        /// <returns></returns>
        [DllImport("shell32")] public static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);
        /// <summary>
        /// 检索有关文件系统中的对象的信息，例如文件，文件夹，目录或驱动器根目录。
        /// </summary>
        /// <param name="pszPath">指向包含路径和文件名的缓冲区。绝对路径和相对路径都是有效的。</param>
        /// <param name="dwFileAttributes">文件属性标志数组（FILE_ATTRIBUTE_值）。如果【uFlags】不包含SHGFI_USEFILEATTRIBUTES值，则忽略该参数。</param>
        /// <param name="psfi">接收文件信息的SHFILEINFO结构的地址和大小（以字节为单位）。</param>
        /// <param name="cbFileInfo">
        /// 指定要检索的文件信息的标志。此参数可以是以下值的组合：
        ///
        /// SHGFI_ATTRIBUTES 检索文件属性标志。标志被复制到由【PSFI】指定的结构的dwAttributes成员。
        /// SHGFI_DISPLAYNAME 检索文件的显示名称。该名称被复制到由【PSFI】指定的结构的szDisplayName成员。
        /// 返回的显示名称使用长文件名（如果有），而不是文件名的8.3形式。
        ///
        /// SHGFI_EXETYPE 如果【* PSFI】标识可执行文件，则返回可执行文件的类型。有关更多信息，请参阅下面的注释。
        /// SHGFI_ICON 检索表示文件的图标的句柄和系统映像列表中图标的索引。该句柄被复制到由【PSFI】指定的结构的惠康成员，索引被复制到图标成员。返回值是系统映像列表的句柄。
        /// SHGFI_ICONLOCATION 检索包含表示文件的图标的文件的名称。该名称复制到【PSFI】指定的结构的szDisplayName成员。
        /// SHGFI_LARGEICON 修改SHGFI_ICON，导致该函数检索文件的大图标。
        /// SHGFI_LINKOVERLAY 修改SHGFI_ICON，导致该函数将链接覆盖添加到文件的图标。
        /// SHGFI_OPENICON 修改SHGFI_ICON，导致该函数检索文件的打开图标。容器对象显示一个打开的图标，表示容器已打开。
        /// SHGFI_PIDL 表示【* PSFI】是ITEMIDLIST结构的地址，而不是路径名称。
        /// SHGFI_SELECTED 修改SHGFI_ICON，使文件的图标与系统突出显示颜色混合。
        /// SHGFI_SHELLICONSIZE 修改SHGFI_ICON，导致该函数检索shell大小的图标。如果未指定此标志，则该函数将根据系统度量值对图标进行大小调整。
        /// SHGFI_SMALLICON 修改SHGFI_ICON，导致该函数检索文件的小图标。
        /// SHGFI_SYSICONINDEX 检索系统映像列表中图标的索引。索引被复制到【PSFI】指定的结构的图标成员。返回值是系统映像列表的句柄。
        /// SHGFI_TYPENAME 检索描述文件类型的字符串。该字符串被复制到由【PSFI】指定的结构的szTypeName成员。
        /// SHGFI_USEFILEATTRIBUTES 表示该函数应使用【dwFileAttributes】参数。
        ///
        /// 要检索可执行文件类型，【uFlags】必须只指定SHGFI_EXETYPE。返回值指定可执行文件的类型：
        ///
        /// 0	不可执行文件或错误条件。
        /// LOWORD = NE or PE
        /// HIWORD = 3.0, 3.5, or 4.0	Windows应用程序
        /// LOWORD = MZ
        /// HIWORD = 0	MS-DOS.EXE，.COM或.BAT文件
        /// LOWORD = PE
        /// HIWORD = 0	Win32控制台应用程序
        /// </param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport("shell32")] public static extern int SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, int uFlags);
        [DllImport("shell32")] public static extern int SHGetNewLinkInfo(string pszLinkto, string pszDir, string pszName, ref int pfMustCopy, int uFlags);
        /// <summary>
        /// 显示“Shell关于”对话框
        /// </summary>
        /// <param name="hwnd">标识父窗口。此参数可以为NULL。</param>
        /// <param name="szApp">标题栏和第一行文本</param>
        /// <param name="szOtherStuff">其他对话框文本</param>
        /// <param name="hIcon">图标显示</param>
        /// <returns></returns>
        [DllImport("shell32")] public static extern int ShellAbout(HWND hwnd, string szApp, string szOtherStuff, HANDLE hIcon);
        /// <summary>
        /// 清空回收站
        /// </summary>
        [DllImport("shell32")] public static extern long SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, long dwFlags);
        /// <summary>
        /// 打开浏览器
        /// </summary>
        /// <param name="hwnd">窗口的句柄</param>
        /// <param name="lpOperation">指定字串“open”来打开lpFlie文档，或指定“Print”来打印它</param>
        /// <param name="lpFile">想用关联程序打印或打开一个程序名或文件名</param>
        /// <param name="lpParameters">可执行文件，则这个字串包含传递给执行程序的参数</param>
        /// <param name="lpDirectory"></param>
        /// <param name="nShowCmd">显示启动程序的常数值</param>
        /// <returns></returns>
        [DllImport("shell32")] public static extern int ShellExecute(HWND hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
        /// <summary>
        /// 向系统发送消息，以从任务栏状态区域添加，修改或删除图标。
        /// </summary>
        /// <param name="dwMessage">要发送的消息的标识符。此参数可以是以下值之一：
        /// NIM_ADD 在状态区域添加图标。
        /// NIM_DELETE 从状态区域中删除图标。
        /// NIM_MODIFY 修改状态区域中的图标。
        /// </param>
        /// <param name="lpData">指向NOTIFYICONDATA结构。结构的内容取决于【dwMessage】的值。</param>
        /// <returns>如果函数成功，返回值不为零。如果函数失败，返回值为零。</returns>
        [DllImport("shell32")] public static extern int Shell_NotifyIcon(int dwMessage, ref NOTIFYICONDATA lpData);
        /// <summary>
        /// 注册窗口是否接受删除的文件
        /// </summary>
        /// <param name="hwnd">标识窗口是否接受丢弃的文件</param>
        /// <param name="fAccept">指定由【hwnd】参数标识的窗口是否接受删除的文件。该值为TRUE以接受丢弃的文件;停止接受丢弃的文件是FALSE。</param>
        [DllImport("shell32")] public static extern void DragAcceptFiles(HWND hwnd, int fAccept);
        /// <summary>
        /// 释放Windows分配用于将文件名传送到应用程序的内存
        /// </summary>
        /// <param name="hDrop">标识描述删除文件的结构。从WM_DROPFILES消息的【wParam中】参数检索该句柄。</param>
        [DllImport("shell32")] public static extern void DragFinish(HANDLE hDrop);
        /// <summary>
        /// 释放由SHFileOperation函数检索的文件名映射对象。
        /// </summary>
        /// <param name="hNameMappings">处理文件名映射对象以释放。</param>
        [DllImport("shell32")] public static extern void SHFreeNameMappings(HANDLE hNameMappings);
        [DllImport("shell32")] public static extern void WinExecError(HWND hwnd, int error, string lpstrFileName, string lpstrTitle);
        /// <summary>
        /// 显示一个对话框，使用户可以选择一个shell文件夹
        /// </summary>
        /// <param name="lpbi">指向BROWSEINFO结构的指针，其中包含用于显示对话框的信息。</param>
        /// <returns>返回指向项目标识符列表的指针，该列表指定所选文件夹相对于名称空间根目录的位置。如果用户在对话框中选择“取消”按钮，返回值为NULL。调用应用程序负责使用shell的任务分配器释放返回的项目标识符列表。</returns>
        [DllImport("shell32")] public static extern int SHBrowseForFolder(BROWSEINFO lpbi);
        /// <summary>
        /// 将项目标识符列表转换为文件系统路径
        /// </summary>
        /// <param name="pidList">指向项目标识符列表，指定相对于名称空间（桌面）根目录的文件或目录位置。</param>
        /// <param name="lpBuffer">指向接收文件系统路径的缓冲区。该缓冲区的大小假定为MAX_PATH个字节。</param>
        /// <returns></returns>
        [DllImport("shell32")] public static extern int SHGetPathFromIDList(int pidList, string lpBuffer);

        public const int ABE_BOTTOM = 3;
        public const int ABE_LEFT = 0;
        public const int ABE_RIGHT = 2;
        public const int ABE_TOP = 1;
        public const int ABM_ACTIVATE = 0x6;
        public const int ABM_GETAUTOHIDEBAR = 0x7;
        public const int ABM_GETSTATE = 0x4;
        public const int ABM_GETTASKBARPOS = 0x5;
        public const int ABM_NEW = 0x0;
        public const int ABM_QUERYPOS = 0x2;
        public const int ABM_REMOVE = 0x1;
        public const int ABM_SETAUTOHIDEBAR = 0x8;
        public const int ABM_SETPOS = 0x3;
        public const int ABM_WINDOWPOSCHANGED = 0x9;
        public const int ABN_FULLSCREENAPP = 0x2;
        public const int ABN_POSCHANGED = 0x1;
        public const int ABN_STATECHANGE = 0x0;
        public const int ABN_WINDOWARRANGE = 0x3;
        public const int ABS_ALWAYSONTOP = 0x2;
        public const int ABS_AUTOHIDE = 0x1;
        public const int EIRESID = -1;
        public const int FOF_ALLOWUNDO = 0x40;
        public const int FOF_CONFIRMMOUSE = 0x2;
        public const int FOF_FILESONLY = 0x80;
        public const int FOF_MULTIDESTFILES = 0x1;
        public const int FOF_NOCONFIRMATION = 0x10;
        public const int FOF_NOCONFIRMMKDIR = 0x200;
        public const int FOF_RENAMEONCOLLISION = 0x8;
        public const int FOF_SILENT = 0x4;
        public const int FOF_SIMPLEPROGRESS = 0x100;
        public const int FOF_WANTMAPPINGHANDLE = 0x20;
        public const int FO_COPY = 0x2;
        public const int FO_DELETE = 0x3;
        public const int FO_MOVE = 0x1;
        public const int FO_RENAME = 0x4;
        public const int NIF_ICON = 0x2;
        public const int NIF_MESSAGE = 0x1;
        public const int NIF_TIP = 0x4;
        public const int NIM_ADD = 0x0;
        public const int NIM_DELETE = 0x2;
        public const int NIM_MODIFY = 0x1;
        public const int PO_DELETE = 0x13;
        public const int PO_PORTCHANGE = 0x20;
        public const int PO_RENAME = 0x14;
        public const int PO_REN_PORT = 0x34;
        public const int SEE_MASK_CLASSKEY = 0x3;
        public const int SEE_MASK_CLASSNAME = 0x1;
        public const int SEE_MASK_CONNECTNETDRV = 0x80;
        public const int SEE_MASK_DOENVSUBST = 0x200;
        public const int SEE_MASK_FLAG_DDEWAIT = 0x100;
        public const int SEE_MASK_FLAG_NO_UI = 0x400;
        public const int SEE_MASK_HOTKEY = 0x20;
        public const int SEE_MASK_ICON = 0x10;
        public const int SEE_MASK_IDLIST = 0x4;
        public const int SEE_MASK_INVOKEIDLIST = 0xC;
        public const int SEE_MASK_NOCLOSEPROCESS = 0x40;
        public const int SE_ERR_ACCESSDENIED = 5;
        public const int SE_ERR_ASSOCINCOMPLETE = 27;
        public const int SE_ERR_DDEBUSY = 30;
        public const int SE_ERR_DDEFAIL = 29;
        public const int SE_ERR_DDETIMEOUT = 28;
        public const int SE_ERR_DLLNOTFOUND = 32;
        public const int SE_ERR_FNF = 2;
        public const int SE_ERR_NOASSOC = 31;
        public const int SE_ERR_OOM = 8;
        public const int SE_ERR_PNF = 3;
        public const int SE_ERR_SHARE = 26;
        public const int SHGFI_ATTRIBUTES = 0x800;
        public const int SHGFI_DISPLAYNAME = 0x200;
        public const int SHGFI_EXETYPE = 0x2000;
        public const int SHGFI_ICON = 0x100;
        public const int SHGFI_ICONLOCATION = 0x1000;
        public const int SHGFI_LARGEICON = 0x0;
        public const int SHGFI_LINKOVERLAY = 0x8000;
        public const int SHGFI_OPENICON = 0x2;
        public const int SHGFI_PIDL = 0x8;
        public const int SHGFI_SELECTED = 0x10000;
        public const int SHGFI_SHELLICONSIZE = 0x4;
        public const int SHGFI_SMALLICON = 0x1;
        public const int SHGFI_SYSICONINDEX = 0x4000;
        public const int SHGFI_TYPENAME = 0x400;
        public const int SHGFI_USEFILEATTRIBUTES = 0x10;
        public const int SHGNLI_PIDL = 0x1;
        public const int SHGNLI_PREFIXNAME = 0x2;
    }
}