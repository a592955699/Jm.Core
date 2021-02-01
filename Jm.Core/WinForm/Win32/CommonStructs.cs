using System.Runtime.InteropServices;
using HANDLE = System.IntPtr;
using HWND = System.IntPtr;

namespace Jm.Core.WinForm.Win32
{
    #region kernel32
    public struct FILETIME
    {
        public int dwLowDateTime;
        public int dwHighDateTime;
    }

    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
    }
    public struct OVERLAPPED
    {
        public int Internal;
        public int InternalHigh;
        public int offset;
        public int OffsetHigh;
        public HANDLE hEvent;
    }
    public struct SECURITY_ATTRIBUTES
    {
        public int nLength;
        public int lpSecurityDescriptor;
        public int bInheritHandle;
    }
    public struct PROCESS_INFORMATION
    {
        public HANDLE hProcess;
        public HANDLE hThread;
        public int dwProcessId;
        public int dwThreadId;
    }
    public struct COMMPROP
    {
        public short wPacketLength;
        public short wPacketVersion;
        public int dwServiceMask;
        public int dwReserved1;
        public int dwMaxTxQueue;
        public int dwMaxRxQueue;
        public int dwMaxBaud;
        public int dwProvSubType;
        public int dwProvCapabilities;
        public int dwSettableParams;
        public int dwSettableBaud;
        public short wSettableData;
        public short wSettableStopParity;
        public int dwCurrentTxQueue;
        public int dwCurrentRxQueue;
        public int dwProvSpec1;
        public int dwProvSpec2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public short[] wcProvChar;
    }
    public struct COMSTAT
    {
        public int fBitFields;
        public int cbInQue;
        public int cbOutQue;
    }
    public struct DCB
    {
        public int DCBlength;
        public int BaudRate;
        public int fBitFields;
        public short wReserved;
        public short XonLim;
        public short XoffLim;
        public byte ByteSize;
        public byte Parity;
        public byte StopBits;
        public byte XonChar;
        public byte XoffChar;
        public byte ErrorChar;
        public byte EofChar;
        public byte EvtChar;
        public short wReserved1;
    }
    public struct COMMTIMEOUTS
    {
        public int ReadIntervalTimeout;
        public int ReadTotalTimeoutMultiplier;
        public int ReadTotalTimeoutConstant;
        public int WriteTotalTimeoutMultiplier;
        public int WriteTotalTimeoutConstant;
    }
    public struct SYSTEM_INFO
    {
        public int dwOemID;
        public int dwPageSize;
        public int lpMinimumApplicationAddress;
        public int lpMaximumApplicationAddress;
        public int dwActiveProcessorMask;
        public int dwNumberOrfProcessors;
        public int dwProcessorType;
        public int dwAllocationGranularity;
        public int dwReserved;
    }
    #region Global Memory Flags
    #endregion
    public struct MEMORYSTATUS
    {
        public int dwLength;
        public int dwMemoryLoad;
        public int dwTotalPhys;
        public int dwAvailPhys;
        public int dwTotalPageFile;
        public int dwAvailPageFile;
        public int dwTotalVirtual;
        public int dwAvailVirtual;
    }
    public struct GENERIC_MAPPING
    {
        public int GenericRead;
        public int GenericWrite;
        public int GenericExecute;
        public int GenericAll;
    }
    public struct LUID
    {
        public int LowPart;
        public int HighPart;
    }
    public struct LUID_AND_ATTRIBUTES
    {
        public LUID pLuid;
        public int Attributes;
    }
    public struct ACL
    {
        public byte AclRevision;
        public byte Sbz1;
        public short AclSize;
        public short AceCount;
        public short Sbz2;
    }
    public struct ACE_HEADER
    {
        public byte AceType;
        public byte AceFlags;
        public int AceSize;
    }
    public struct ACCESS_ALLOWED_ACE
    {
        public ACE_HEADER Header;
        public int Mask;
        public int SidStart;
    }
    public struct ACCESS_DENIED_ACE
    {
        public ACE_HEADER Header;
        public int Mask;
        public int SidStart;
    }
    public struct SYSTEM_AUDIT_ACE
    {
        public ACE_HEADER Header;
        public int Mask;
        public int SidStart;
    }
    public struct SYSTEM_ALARM_ACE
    {
        public ACE_HEADER Header;
        public int Mask;
        public int SidStart;
    }
    public struct ACL_REVISION_INFORMATION
    {
        public int AclRevision;
    }
    public struct ACL_SIZE_INFORMATION
    {
        public int AceCount;
        public int AclBytesInUse;
        public int AclBytesFree;
    }
    public struct SECURITY_DESCRIPTOR
    {
        public byte Revision;
        public byte Sbz1;
        public int Control;
        public int Owner;
        public int Group;
        public ACL Sacl;
        public ACL Dacl;
    }
    public struct PRIVILEGE_SET
    {
        public int PrivilegeCount;
        public int Control;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public LUID_AND_ATTRIBUTES[] Privilege;
    }
    public struct EXCEPTION_RECORD
    {
        public int ExceptionCode;
        public int ExceptionFlags;
        public int pExceptionRecord;
        public int ExceptionAddress;
        public int NumberParameters;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public int[] ExceptionInformation;
    }
    public struct EXCEPTION_DEBUG_INFO
    {
        public EXCEPTION_RECORD pExceptionRecord;
        public int dwFirstChance;
    }
    public struct CREATE_THREAD_DEBUG_INFO
    {
        public HANDLE hThread;
        public int lpThreadLocalBase;
        public int lpStartAddress;
    }
    public struct CREATE_PROCESS_DEBUG_INFO
    {
        public HANDLE hFile;
        public HANDLE hProcess;
        public HANDLE hThread;
        public int lpBaseOfImage;
        public int dwDebugInfoFileOffset;
        public int nDebugInfoSize;
        public int lpThreadLocalBase;
        public int lpStartAddress;
        public int lpImageName;
        public short fUnicode;
    }
    public struct EXIT_THREAD_DEBUG_INFO
    {
        public int dwExitCode;
    }
    public struct EXIT_PROCESS_DEBUG_INFO
    {
        public int dwExitCode;
    }
    public struct LOAD_DLL_DEBUG_INFO
    {
        public HANDLE hFile;
        public int lpBaseOfDll;
        public int dwDebugInfoFileOffset;
        public int nDebugInfoSize;
        public int lpImageName;
        public short fUnicode;
    }
    public struct UNLOAD_DLL_DEBUG_INFO
    {
        public int lpBaseOfDll;
    }
    public struct OUTPUT_DEBUG_STRING_INFO
    {
        public string lpDebugStringData;
        public short fUnicode;
        public short nDebugStringLength;
    }
    public struct RIP_INFO
    {
        public int dwError;
        public int dwType;
    }
    public struct OFSTRUCT
    {
        public byte cBytes;
        public byte fFixedDisk;
        public short nErrCode;
        public short Reserved1;
        public short Reserved2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] public byte[] szPathName;
    }
    public struct CRITICAL_SECTION
    {
        public int pDebugInfo;
        public int LockCount;
        public int RecursionCount;
        public int pOwningThread;
        public int pLockSemaphore;
        public int Reserved;
    }
    public struct BY_HANDLE_FILE_INFORMATION
    {
        public int dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public int dwVolumeSerialNumber;
        public int nFileSizeHigh;
        public int nFileSizeLow;
        public int nNumberOfLinks;
        public int nFileIndexHigh;
        public int nFileIndexLow;
    }
    public struct MEMORY_BASIC_INFORMATION
    {
        public int BaseAddress;
        public int AllocationBase;
        public int AllocationProtect;
        public int RegionSize;
        public int State;
        public int Protect;
        public int lType;
    }
    public struct EVENTLOGRECORD
    {
        public int Length;
        public int Reserved;
        public int RecordNumber;
        public int TimeGenerated;
        public int TimeWritten;
        public int EventID;
        public short EventType;
        public short NumStrings;
        public short EventCategory;
        public short ReservedFlags;
        public int ClosingRecordNumber;
        public int StringOffset;
        public int UserSidLength;
        public int UserSidOffset;
        public int DataLength;
        public int DataOffset;
    }
    public struct TOKEN_GROUPS
    {
        public int GroupCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public SID_AND_ATTRIBUTES[] Groups;
    }
    public struct TOKEN_PRIVILEGES
    {
        public int PrivilegeCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public LUID_AND_ATTRIBUTES[] Privileges;
    }
    public struct CONTEXT
    {
        public double FltF0;
        public double FltF1;
        public double FltF2;
        public double FltF3;
        public double FltF4;
        public double FltF5;
        public double FltF6;
        public double FltF7;
        public double FltF8;
        public double FltF9;
        public double FltF10;
        public double FltF11;
        public double FltF12;
        public double FltF13;
        public double FltF14;
        public double FltF15;
        public double FltF16;
        public double FltF17;
        public double FltF18;
        public double FltF19;
        public double FltF20;
        public double FltF21;
        public double FltF22;
        public double FltF23;
        public double FltF24;
        public double FltF25;
        public double FltF26;
        public double FltF27;
        public double FltF28;
        public double FltF29;
        public double FltF30;
        public double FltF31;
        public double IntV0;
        public double IntT0;
        public double IntT1;
        public double IntT2;
        public double IntT3;
        public double IntT4;
        public double IntT5;
        public double IntT6;
        public double IntT7;
        public double IntS0;
        public double IntS1;
        public double IntS2;
        public double IntS3;
        public double IntS4;
        public double IntS5;
        public double IntFp;
        public double IntA0;
        public double IntA1;
        public double IntA2;
        public double IntA3;
        public double IntA4;
        public double IntA5;
        public double IntT8;
        public double IntT9;
        public double IntT10;
        public double IntT11;
        public double IntRa;
        public double IntT12;
        public double IntAt;
        public double IntGp;
        public double IntSp;
        public double IntZero;
        public double Fpcr;
        public double SoftFpcr;
        public double Fir;
        public int Psr;
        public int ContextFlags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public int[] Fill;
    }
    public struct EXCEPTION_POINTERS
    {
        public EXCEPTION_RECORD pExceptionRecord;
        public CONTEXT ContextRecord;
    }
    public struct LDT_BYTES
    {
        public byte BaseMid;
        public byte Flags1;
        public byte Flags2;
        public byte BaseHi;
    }
    public struct LDT_ENTRY
    {
        public short LimitLow;
        public short BaseLow;
        public int HighWord;
    }
    public struct TIME_ZONE_INFORMATION
    {
        public int Bias;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public short[] StandardName;
        public SYSTEMTIME StandardDate;
        public int StandardBias;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public short[] DaylightName;
        public SYSTEMTIME DaylightDate;
        public int DaylightBias;
    }
    public struct WIN32_STREAM_ID
    {
        public int dwStreamID;
        public int dwStreamAttributes;
        public int dwStreamSizeLow;
        public int dwStreamSizeHigh;
        public int dwStreamNameSize;
        public byte cStreamName;
    }
    public struct STARTUPINFO
    {
        public int cb;
        public string lpReserved;
        public string lpDesktop;
        public string lpTitle;
        public int dwX;
        public int dwY;
        public int dwXSize;
        public int dwYSize;
        public int dwXCountChars;
        public int dwYCountChars;
        public int dwFillAttribute;
        public int dwFlags;
        public short wShowWindow;
        public short cbReserved2;
        public int lpReserved2;
        public HANDLE hStdInput;
        public HANDLE hStdOutput;
        public HANDLE hStdError;
    }
    public struct CPINFO
    {
        public int MaxCharSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonConsts.MAX_DEFAULTCHAR)] public byte[] DefaultChar;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonConsts.MAX_LEADBYTES)] public byte[] LeadByte;
    }
    public struct NUMBERFMT
    {
        public int NumDigits;
        public int LeadingZero;
        public int Grouping;
        public string lpDecimalSep;
        public string lpThousandSep;
        public int NegativeOrder;
    }
    public struct CURRENCYFMT
    {
        public int NumDigits;
        public int LeadingZero;
        public int Grouping;
        public string lpDecimalSep;
        public string lpThousandSep;
        public int NegativeOrder;
        public int PositiveOrder;
        public string lpCurrencySymbol;
    }
    public struct COORD
    {
        public short x;
        public short y;
    }
    public struct SMALL_RECT
    {
        public short Left;
        public short Top;
        public short Right;
        public short Bottom;
    }
    public struct KEY_EVENT_RECORD
    {
        public int bKeyDown;
        public short wRepeatCount;
        public short wVirtualKeyCode;
        public short wVirtualScanCode;
        public byte uChar;
        public int dwControlKeyState;
    }
    public struct MOUSE_EVENT_RECORD
    {
        public COORD dwMousePosition;
        public int dwButtonState;
        public int dwControlKeyState;
        public int dwEventFlags;
    }
    public struct WINDOW_BUFFER_SIZE_RECORD
    {
        public COORD dwSize;
    }
    public struct MENU_EVENT_RECORD
    {
        public int dwCommandId;
    }
    public struct FOCUS_EVENT_RECORD
    {
        public int bSetFocus;
    }
    public struct CHAR_INFO
    {
        public short Char;
        public short Attributes;
    }
    public struct CONSOLE_SCREEN_BUFFER_INFO
    {
        public COORD dwSize;
        public COORD dwCursorPosition;
        public short wAttributes;
        public SMALL_RECT srWindow;
        public COORD dwMaximumWindowSize;
    }
    public struct CONSOLE_CURSOR_INFO
    {
        public int dwSize;
        public int bVisible;
    }
    public struct SID_IDENTIFIER_AUTHORITY
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)] public byte[] Value;
    }
    public struct SID_AND_ATTRIBUTES
    {
        public int Sid;
        public int Attributes;
    }
    public struct WIN32_FIND_DATA
    {
        public int dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public int nFileSizeHigh;
        public int nFileSizeLow;
        public int dwReserved0;
        public int dwReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CommonConsts.MAX_PATH)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternate;
    }
    public struct COMMCONFIG
    {
        public int dwSize;
        public short wVersion;
        public short wReserved;
        public DCB dcbx;
        public int dwProviderSubType;
        public int dwProviderOffset;
        public int dwProviderSize;
        public byte wcProviderData;
    }
    public struct SERVICE_STATUS
    {
        public int dwServiceType;
        public int dwCurrentState;
        public int dwControlsAccepted;
        public int dwWin32ExitCode;
        public int dwServiceSpecificExitCode;
        public int dwCheckPoint;
        public int dwWaitHint;
    }
    public struct ENUM_SERVICE_STATUS
    {
        public string lpServiceName;
        public string lpDisplayName;
        public SERVICE_STATUS ServiceStatus;
    }
    public struct QUERY_SERVICE_LOCK_STATUS
    {
        public int fIsLocked;
        public string lpLockOwner;
        public int dwLockDuration;
    }
    public struct QUERY_SERVICE_CONFIG
    {
        public int dwServiceType;
        public int dwStartType;
        public int dwErrorControl;
        public string lpBinaryPathName;
        public string lpLoadOrderGroup;
        public int dwTagId;
        public string lpDependencies;
        public string lpServiceStartName;
        public string lpDisplayName;
    }
    public struct SERVICE_TABLE_ENTRY
    {
        public string lpServiceName;
        public int lpServiceProc;
    }
    public struct LARGE_INTEGER
    {
        public int lowpart;
        public int highpart;
    }
    public struct PERF_DATA_BLOCK
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)] public string Signature;
        public int LittleEndian;
        public int Version;
        public int Revision;
        public int TotalByteLength;
        public int HeaderLength;
        public int NumObjectTypes;
        public int DefaultObject;
        public SYSTEMTIME SystemTime;
        public LARGE_INTEGER PerfTime;
        public LARGE_INTEGER PerfFreq;
        public LARGE_INTEGER PerTime100nSec;
        public int SystemNameLength;
        public int SystemNameOffset;
    }
    public struct PERF_OBJECT_TYPE
    {
        public int TotalByteLength;
        public int DefinitionLength;
        public int HeaderLength;
        public int ObjectNameTitleIndex;
        public string ObjectNameTitle;
        public int ObjectHelpTitleIndex;
        public string ObjectHelpTitle;
        public int DetailLevel;
        public int NumCounters;
        public int DefaultCounter;
        public int NumInstances;
        public int CodePage;
        public LARGE_INTEGER PerfTime;
        public LARGE_INTEGER PerfFreq;
    }
    public struct PERF_COUNTER_DEFINITION
    {
        public int ByteLength;
        public int CounterNameTitleIndex;
        public string CounterNameTitle;
        public int CounterHelpTitleIndex;
        public string CounterHelpTitle;
        public int DefaultScale;
        public int DetailLevel;
        public int CounterType;
        public int CounterSize;
        public int CounterOffset;
    }
    public struct PERF_INSTANCE_DEFINITION
    {
        public int ByteLength;
        public int ParentObjectTitleIndex;
        public int ParentObjectInstance;
        public int UniqueID;
        public int NameOffset;
        public int NameLength;
    }
    public struct PERF_COUNTER_BLOCK
    {
        public int ByteLength;
    }
    public struct OSVERSIONINFO
    {
        public int dwOSVersionInfoSize;
        public int dwMajorVersion;
        public int dwMinorVersion;
        public int dwBuildNumber;
        public int dwPlatformId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)] public string szCSDVersion;
    }
    public struct SYSTEM_POWER_STATUS
    {
        public byte ACLineStatus;
        public byte BatteryFlag;
        public byte BatteryLifePercent;
        public byte Reserved1;
        public int BatteryLifeTime;
        public int BatteryFullLifeTime;
    }
    #endregion

    #region shell32
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonConsts.MAX_PATH)] public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] public string szTypeName;
    }
    #endregion

    #region user32
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    public struct POINT
    {
        public int x;
        public int y;
    }
    #endregion
}
