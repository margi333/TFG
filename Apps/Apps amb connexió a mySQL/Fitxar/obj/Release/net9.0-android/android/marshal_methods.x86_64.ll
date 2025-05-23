; ModuleID = 'marshal_methods.x86_64.ll'
source_filename = "marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [159 x ptr] zeroinitializer, align 16

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [477 x i64] [
	i64 u0x0071cf2d27b7d61e, ; 0: lib_Xamarin.AndroidX.SwipeRefreshLayout.dll.so => 80
	i64 u0x02123411c4e01926, ; 1: lib_Xamarin.AndroidX.Navigation.Runtime.dll.so => 76
	i64 u0x02abedc11addc1ed, ; 2: lib_Mono.Android.Runtime.dll.so => 157
	i64 u0x032267b2a94db371, ; 3: lib_Xamarin.AndroidX.AppCompat.dll.so => 59
	i64 u0x043032f1d071fae0, ; 4: ru/Microsoft.Maui.Controls.resources => 24
	i64 u0x044440a55165631e, ; 5: lib-cs-Microsoft.Maui.Controls.resources.dll.so => 2
	i64 u0x046eb1581a80c6b0, ; 6: vi/Microsoft.Maui.Controls.resources => 30
	i64 u0x0517ef04e06e9f76, ; 7: System.Net.Primitives => 116
	i64 u0x0565d18c6da3de38, ; 8: Xamarin.AndroidX.RecyclerView => 78
	i64 u0x0581db89237110e9, ; 9: lib_System.Collections.dll.so => 93
	i64 u0x05989cb940b225a9, ; 10: Microsoft.Maui.dll => 50
	i64 u0x05a1c25e78e22d87, ; 11: lib_System.Runtime.CompilerServices.Unsafe.dll.so => 126
	i64 u0x06076b5d2b581f08, ; 12: zh-HK/Microsoft.Maui.Controls.resources => 31
	i64 u0x0680a433c781bb3d, ; 13: Xamarin.AndroidX.Collection.Jvm => 62
	i64 u0x07c57877c7ba78ad, ; 14: ru/Microsoft.Maui.Controls.resources.dll => 24
	i64 u0x07dcdc7460a0c5e4, ; 15: System.Collections.NonGeneric => 91
	i64 u0x08f3c9788ee2153c, ; 16: Xamarin.AndroidX.DrawerLayout => 67
	i64 u0x0919c28b89381a0b, ; 17: lib_Microsoft.Extensions.Options.dll.so => 46
	i64 u0x092266563089ae3e, ; 18: lib_System.Collections.NonGeneric.dll.so => 91
	i64 u0x09d144a7e214d457, ; 19: System.Security.Cryptography => 139
	i64 u0x0abb3e2b271edc45, ; 20: System.Threading.Channels.dll => 146
	i64 u0x0b3b632c3bbee20c, ; 21: sk/Microsoft.Maui.Controls.resources => 25
	i64 u0x0b6aff547b84fbe9, ; 22: Xamarin.KotlinX.Serialization.Core.Jvm => 86
	i64 u0x0be2e1f8ce4064ed, ; 23: Xamarin.AndroidX.ViewPager => 81
	i64 u0x0c3ca6cc978e2aae, ; 24: pt-BR/Microsoft.Maui.Controls.resources => 21
	i64 u0x0c59ad9fbbd43abe, ; 25: Mono.Android => 158
	i64 u0x0c7790f60165fc06, ; 26: lib_Microsoft.Maui.Essentials.dll.so => 51
	i64 u0x0e14e73a54dda68e, ; 27: lib_System.Net.NameResolution.dll.so => 114
	i64 u0x102a31b45304b1da, ; 28: Xamarin.AndroidX.CustomView => 66
	i64 u0x10f6cfcbcf801616, ; 29: System.IO.Compression.Brotli => 107
	i64 u0x114443cdcf2091f1, ; 30: System.Security.Cryptography.Primitives => 137
	i64 u0x124f38a5d8cb5fb8, ; 31: K4os.Compression.LZ4.dll => 37
	i64 u0x125b7f94acb989db, ; 32: Xamarin.AndroidX.RecyclerView.dll => 78
	i64 u0x13a01de0cbc3f06c, ; 33: lib-fr-Microsoft.Maui.Controls.resources.dll.so => 8
	i64 u0x13f1e5e209e91af4, ; 34: lib_Java.Interop.dll.so => 156
	i64 u0x13f1e880c25d96d1, ; 35: he/Microsoft.Maui.Controls.resources => 9
	i64 u0x143d8ea60a6a4011, ; 36: Microsoft.Extensions.DependencyInjection.Abstractions => 43
	i64 u0x152a448bd1e745a7, ; 37: Microsoft.Win32.Primitives => 89
	i64 u0x159cc6c81072f00e, ; 38: lib_System.Diagnostics.EventLog.dll.so => 55
	i64 u0x16ea2b318ad2d830, ; 39: System.Security.Cryptography.Algorithms => 134
	i64 u0x17b56e25558a5d36, ; 40: lib-hu-Microsoft.Maui.Controls.resources.dll.so => 12
	i64 u0x17f9358913beb16a, ; 41: System.Text.Encodings.Web => 143
	i64 u0x18402a709e357f3b, ; 42: lib_Xamarin.KotlinX.Serialization.Core.Jvm.dll.so => 86
	i64 u0x18a9befae51bb361, ; 43: System.Net.WebClient => 120
	i64 u0x18f0ce884e87d89a, ; 44: nb/Microsoft.Maui.Controls.resources.dll => 18
	i64 u0x19a4c090f14ebb66, ; 45: System.Security.Claims => 133
	i64 u0x1a91866a319e9259, ; 46: lib_System.Collections.Concurrent.dll.so => 90
	i64 u0x1aac34d1917ba5d3, ; 47: lib_System.dll.so => 154
	i64 u0x1aad60783ffa3e5b, ; 48: lib-th-Microsoft.Maui.Controls.resources.dll.so => 27
	i64 u0x1c753b5ff15bce1b, ; 49: Mono.Android.Runtime.dll => 157
	i64 u0x1dba6509cc55b56f, ; 50: lib_Google.Protobuf.dll.so => 36
	i64 u0x1e3d87657e9659bc, ; 51: Xamarin.AndroidX.Navigation.UI => 77
	i64 u0x1e71143913d56c10, ; 52: lib-ko-Microsoft.Maui.Controls.resources.dll.so => 16
	i64 u0x1ed8fcce5e9b50a0, ; 53: Microsoft.Extensions.Options.dll => 46
	i64 u0x1f055d15d807e1b2, ; 54: System.Xml.XmlSerializer => 153
	i64 u0x20237ea48006d7a8, ; 55: lib_System.Net.WebClient.dll.so => 120
	i64 u0x209375905fcc1bad, ; 56: lib_System.IO.Compression.Brotli.dll.so => 107
	i64 u0x20edad43b59fbd8e, ; 57: System.Security.Permissions.dll => 57
	i64 u0x20fab3cf2dfbc8df, ; 58: lib_System.Diagnostics.Process.dll.so => 101
	i64 u0x2174319c0d835bc9, ; 59: System.Runtime => 132
	i64 u0x220fd4f2e7c48170, ; 60: th/Microsoft.Maui.Controls.resources => 27
	i64 u0x234b2420fe4b9bdc, ; 61: lib_K4os.Compression.LZ4.dll.so => 37
	i64 u0x237be844f1f812c7, ; 62: System.Threading.Thread.dll => 147
	i64 u0x2407aef2bbe8fadf, ; 63: System.Console => 98
	i64 u0x240abe014b27e7d3, ; 64: Xamarin.AndroidX.Core.dll => 64
	i64 u0x252073cc3caa62c2, ; 65: fr/Microsoft.Maui.Controls.resources.dll => 8
	i64 u0x2662c629b96b0b30, ; 66: lib_Xamarin.Kotlin.StdLib.dll.so => 84
	i64 u0x268c1439f13bcc29, ; 67: lib_Microsoft.Extensions.Primitives.dll.so => 47
	i64 u0x273f3515de5faf0d, ; 68: id/Microsoft.Maui.Controls.resources.dll => 13
	i64 u0x2742545f9094896d, ; 69: hr/Microsoft.Maui.Controls.resources => 11
	i64 u0x27b410442fad6cf1, ; 70: Java.Interop.dll => 156
	i64 u0x2801845a2c71fbfb, ; 71: System.Net.Primitives.dll => 116
	i64 u0x2a128783efe70ba0, ; 72: uk/Microsoft.Maui.Controls.resources.dll => 29
	i64 u0x2a3b095612184159, ; 73: lib_System.Net.NetworkInformation.dll.so => 115
	i64 u0x2a6507a5ffabdf28, ; 74: System.Diagnostics.TraceSource.dll => 103
	i64 u0x2ad156c8e1354139, ; 75: fi/Microsoft.Maui.Controls.resources => 7
	i64 u0x2af298f63581d886, ; 76: System.Text.RegularExpressions.dll => 145
	i64 u0x2afc1c4f898552ee, ; 77: lib_System.Formats.Asn1.dll.so => 106
	i64 u0x2b148910ed40fbf9, ; 78: zh-Hant/Microsoft.Maui.Controls.resources.dll => 33
	i64 u0x2c8bd14bb93a7d82, ; 79: lib-pl-Microsoft.Maui.Controls.resources.dll.so => 20
	i64 u0x2cbd9262ca785540, ; 80: lib_System.Text.Encoding.CodePages.dll.so => 141
	i64 u0x2d169d318a968379, ; 81: System.Threading.dll => 149
	i64 u0x2d47774b7d993f59, ; 82: sv/Microsoft.Maui.Controls.resources.dll => 26
	i64 u0x2db915caf23548d2, ; 83: System.Text.Json.dll => 144
	i64 u0x2e6f1f226821322a, ; 84: el/Microsoft.Maui.Controls.resources.dll => 5
	i64 u0x2f02f94df3200fe5, ; 85: System.Diagnostics.Process => 101
	i64 u0x2f2e98e1c89b1aff, ; 86: System.Xml.ReaderWriter => 152
	i64 u0x309ee9eeec09a71e, ; 87: lib_Xamarin.AndroidX.Fragment.dll.so => 68
	i64 u0x31195fef5d8fb552, ; 88: _Microsoft.Android.Resource.Designer.dll => 34
	i64 u0x32243413e774362a, ; 89: Xamarin.AndroidX.CardView.dll => 61
	i64 u0x3235427f8d12dae1, ; 90: lib_System.Drawing.Primitives.dll.so => 104
	i64 u0x329753a17a517811, ; 91: fr/Microsoft.Maui.Controls.resources => 8
	i64 u0x32aa989ff07a84ff, ; 92: lib_System.Xml.ReaderWriter.dll.so => 152
	i64 u0x33a31443733849fe, ; 93: lib-es-Microsoft.Maui.Controls.resources.dll.so => 6
	i64 u0x341abc357fbb4ebf, ; 94: lib_System.Net.Sockets.dll.so => 119
	i64 u0x34dfd74fe2afcf37, ; 95: Microsoft.Maui => 50
	i64 u0x34e292762d9615df, ; 96: cs/Microsoft.Maui.Controls.resources.dll => 2
	i64 u0x3508234247f48404, ; 97: Microsoft.Maui.Controls => 48
	i64 u0x3549870798b4cd30, ; 98: lib_Xamarin.AndroidX.ViewPager2.dll.so => 82
	i64 u0x355282fc1c909694, ; 99: Microsoft.Extensions.Configuration => 40
	i64 u0x355c649948d55d97, ; 100: lib_System.Runtime.Intrinsics.dll.so => 128
	i64 u0x38049b5c59b39324, ; 101: System.Runtime.CompilerServices.Unsafe => 126
	i64 u0x385c17636bb6fe6e, ; 102: Xamarin.AndroidX.CustomView.dll => 66
	i64 u0x38869c811d74050e, ; 103: System.Net.NameResolution.dll => 114
	i64 u0x39251dccb84bdcaa, ; 104: lib_System.Configuration.ConfigurationManager.dll.so => 54
	i64 u0x393c226616977fdb, ; 105: lib_Xamarin.AndroidX.ViewPager.dll.so => 81
	i64 u0x395e37c3334cf82a, ; 106: lib-ca-Microsoft.Maui.Controls.resources.dll.so => 1
	i64 u0x3ab5859054645f72, ; 107: System.Security.Cryptography.Primitives.dll => 137
	i64 u0x3b2c47fe17204e4d, ; 108: MySql.Data => 53
	i64 u0x3b860f9932505633, ; 109: lib_System.Text.Encoding.Extensions.dll.so => 142
	i64 u0x3c3aafb6b3a00bf6, ; 110: lib_System.Security.Cryptography.X509Certificates.dll.so => 138
	i64 u0x3c7c495f58ac5ee9, ; 111: Xamarin.Kotlin.StdLib => 84
	i64 u0x3d2b1913edfc08d7, ; 112: lib_System.Threading.ThreadPool.dll.so => 148
	i64 u0x3d9c2a242b040a50, ; 113: lib_Xamarin.AndroidX.Core.dll.so => 64
	i64 u0x3daa14724d8f58e8, ; 114: Google.Protobuf.dll => 36
	i64 u0x4019503dd3d938a1, ; 115: MySql.Data.dll => 53
	i64 u0x407a10bb4bf95829, ; 116: lib_Xamarin.AndroidX.Navigation.Common.dll.so => 74
	i64 u0x415e36f6b13ff6f3, ; 117: System.Configuration.ConfigurationManager.dll => 54
	i64 u0x41cab042be111c34, ; 118: lib_Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so => 60
	i64 u0x434c4e1d9284cdae, ; 119: Mono.Android.dll => 158
	i64 u0x43950f84de7cc79a, ; 120: pl/Microsoft.Maui.Controls.resources.dll => 20
	i64 u0x4515080865a951a5, ; 121: Xamarin.Kotlin.StdLib.dll => 84
	i64 u0x45c40276a42e283e, ; 122: System.Diagnostics.TraceSource => 103
	i64 u0x46a4213bc97fe5ae, ; 123: lib-ru-Microsoft.Maui.Controls.resources.dll.so => 24
	i64 u0x47daf4e1afbada10, ; 124: pt/Microsoft.Maui.Controls.resources => 22
	i64 u0x4953c088b9debf0a, ; 125: lib_System.Security.Permissions.dll.so => 57
	i64 u0x49e952f19a4e2022, ; 126: System.ObjectModel => 123
	i64 u0x4a5667b2462a664b, ; 127: lib_Xamarin.AndroidX.Navigation.UI.dll.so => 77
	i64 u0x4b7b6532ded934b7, ; 128: System.Text.Json => 144
	i64 u0x4cc5f15266470798, ; 129: lib_Xamarin.AndroidX.Loader.dll.so => 73
	i64 u0x4cf6f67dc77aacd2, ; 130: System.Net.NetworkInformation.dll => 115
	i64 u0x4d479f968a05e504, ; 131: System.Linq.Expressions.dll => 110
	i64 u0x4d55a010ffc4faff, ; 132: System.Private.Xml => 125
	i64 u0x4d95fccc1f67c7ca, ; 133: System.Runtime.Loader.dll => 129
	i64 u0x4dcf44c3c9b076a2, ; 134: it/Microsoft.Maui.Controls.resources.dll => 14
	i64 u0x4dd9247f1d2c3235, ; 135: Xamarin.AndroidX.Loader.dll => 73
	i64 u0x4e32f00cb0937401, ; 136: Mono.Android.Runtime => 157
	i64 u0x4e5eea4668ac2b18, ; 137: System.Text.Encoding.CodePages => 141
	i64 u0x4ebd0c4b82c5eefc, ; 138: lib_System.Threading.Channels.dll.so => 146
	i64 u0x4f21ee6ef9eb527e, ; 139: ca/Microsoft.Maui.Controls.resources => 1
	i64 u0x5037f0be3c28c7a3, ; 140: lib_Microsoft.Maui.Controls.dll.so => 48
	i64 u0x5131bbe80989093f, ; 141: Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll => 71
	i64 u0x51bb8a2afe774e32, ; 142: System.Drawing => 105
	i64 u0x526ce79eb8e90527, ; 143: lib_System.Net.Primitives.dll.so => 116
	i64 u0x52829f00b4467c38, ; 144: lib_System.Data.Common.dll.so => 99
	i64 u0x529ffe06f39ab8db, ; 145: Xamarin.AndroidX.Core => 64
	i64 u0x52ff996554dbf352, ; 146: Microsoft.Maui.Graphics => 52
	i64 u0x535f7e40e8fef8af, ; 147: lib-sk-Microsoft.Maui.Controls.resources.dll.so => 25
	i64 u0x53a96d5c86c9e194, ; 148: System.Net.NetworkInformation => 115
	i64 u0x53c3014b9437e684, ; 149: lib-zh-HK-Microsoft.Maui.Controls.resources.dll.so => 31
	i64 u0x5435e6f049e9bc37, ; 150: System.Security.Claims.dll => 133
	i64 u0x54795225dd1587af, ; 151: lib_System.Runtime.dll.so => 132
	i64 u0x556e8b63b660ab8b, ; 152: Xamarin.AndroidX.Lifecycle.Common.Jvm.dll => 69
	i64 u0x5588627c9a108ec9, ; 153: System.Collections.Specialized => 92
	i64 u0x571c5cfbec5ae8e2, ; 154: System.Private.Uri => 124
	i64 u0x579a06fed6eec900, ; 155: System.Private.CoreLib.dll => 155
	i64 u0x57c542c14049b66d, ; 156: System.Diagnostics.DiagnosticSource => 100
	i64 u0x58601b2dda4a27b9, ; 157: lib-ja-Microsoft.Maui.Controls.resources.dll.so => 15
	i64 u0x58688d9af496b168, ; 158: Microsoft.Extensions.DependencyInjection.dll => 42
	i64 u0x5a89a886ae30258d, ; 159: lib_Xamarin.AndroidX.CoordinatorLayout.dll.so => 63
	i64 u0x5a8f6699f4a1caa9, ; 160: lib_System.Threading.dll.so => 149
	i64 u0x5ae9cd33b15841bf, ; 161: System.ComponentModel => 97
	i64 u0x5b5f0e240a06a2a2, ; 162: da/Microsoft.Maui.Controls.resources.dll => 3
	i64 u0x5b608c01082a90a8, ; 163: K4os.Hash.xxHash => 39
	i64 u0x5c393624b8176517, ; 164: lib_Microsoft.Extensions.Logging.dll.so => 44
	i64 u0x5d0a4a29b02d9d3c, ; 165: System.Net.WebHeaderCollection.dll => 121
	i64 u0x5db0cbbd1028510e, ; 166: lib_System.Runtime.InteropServices.dll.so => 127
	i64 u0x5db30905d3e5013b, ; 167: Xamarin.AndroidX.Collection.Jvm.dll => 62
	i64 u0x5e467bc8f09ad026, ; 168: System.Collections.Specialized.dll => 92
	i64 u0x5ea92fdb19ec8c4c, ; 169: System.Text.Encodings.Web.dll => 143
	i64 u0x5eb8046dd40e9ac3, ; 170: System.ComponentModel.Primitives => 95
	i64 u0x5ec272d219c9aba4, ; 171: System.Security.Cryptography.Csp.dll => 135
	i64 u0x5f36ccf5c6a57e24, ; 172: System.Xml.ReaderWriter.dll => 152
	i64 u0x5f4294b9b63cb842, ; 173: System.Data.Common => 99
	i64 u0x5f9a2d823f664957, ; 174: lib-el-Microsoft.Maui.Controls.resources.dll.so => 5
	i64 u0x5fac98e0b37a5b9d, ; 175: System.Runtime.CompilerServices.Unsafe.dll => 126
	i64 u0x609f4b7b63d802d4, ; 176: lib_Microsoft.Extensions.DependencyInjection.dll.so => 42
	i64 u0x60cd4e33d7e60134, ; 177: Xamarin.KotlinX.Coroutines.Core.Jvm => 85
	i64 u0x60f62d786afcf130, ; 178: System.Memory => 112
	i64 u0x618073e67851e2a7, ; 179: lib_K4os.Compression.LZ4.Streams.dll.so => 38
	i64 u0x61be8d1299194243, ; 180: Microsoft.Maui.Controls.Xaml => 49
	i64 u0x61d2cba29557038f, ; 181: de/Microsoft.Maui.Controls.resources => 4
	i64 u0x61d88f399afb2f45, ; 182: lib_System.Runtime.Loader.dll.so => 129
	i64 u0x622eef6f9e59068d, ; 183: System.Private.CoreLib => 155
	i64 u0x6400f68068c1e9f1, ; 184: Xamarin.Google.Android.Material.dll => 83
	i64 u0x640e3b14dbd325c2, ; 185: System.Security.Cryptography.Algorithms.dll => 134
	i64 u0x65a51fb1cf95ad53, ; 186: ZstdSharp.dll => 87
	i64 u0x65ecac39144dd3cc, ; 187: Microsoft.Maui.Controls.dll => 48
	i64 u0x65ece51227bfa724, ; 188: lib_System.Runtime.Numerics.dll.so => 130
	i64 u0x6692e924eade1b29, ; 189: lib_System.Console.dll.so => 98
	i64 u0x66a4e5c6a3fb0bae, ; 190: lib_Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll.so => 71
	i64 u0x66d13304ce1a3efa, ; 191: Xamarin.AndroidX.CursorAdapter => 65
	i64 u0x68558ec653afa616, ; 192: lib-da-Microsoft.Maui.Controls.resources.dll.so => 3
	i64 u0x6872ec7a2e36b1ac, ; 193: System.Drawing.Primitives.dll => 104
	i64 u0x68b23655cc17aa45, ; 194: Fitxar => 88
	i64 u0x68fbbbe2eb455198, ; 195: System.Formats.Asn1 => 106
	i64 u0x69063fc0ba8e6bdd, ; 196: he/Microsoft.Maui.Controls.resources.dll => 9
	i64 u0x6a4d7577b2317255, ; 197: System.Runtime.InteropServices.dll => 127
	i64 u0x6ace3b74b15ee4a4, ; 198: nb/Microsoft.Maui.Controls.resources => 18
	i64 u0x6d0a12b2adba20d8, ; 199: System.Security.Cryptography.ProtectedData.dll => 56
	i64 u0x6d12bfaa99c72b1f, ; 200: lib_Microsoft.Maui.Graphics.dll.so => 52
	i64 u0x6d70755158ca866e, ; 201: lib_System.ComponentModel.EventBasedAsync.dll.so => 94
	i64 u0x6d79993361e10ef2, ; 202: Microsoft.Extensions.Primitives => 47
	i64 u0x6d86d56b84c8eb71, ; 203: lib_Xamarin.AndroidX.CursorAdapter.dll.so => 65
	i64 u0x6d9bea6b3e895cf7, ; 204: Microsoft.Extensions.Primitives.dll => 47
	i64 u0x6e25a02c3833319a, ; 205: lib_Xamarin.AndroidX.Navigation.Fragment.dll.so => 75
	i64 u0x6fd2265da78b93a4, ; 206: lib_Microsoft.Maui.dll.so => 50
	i64 u0x6fdfc7de82c33008, ; 207: cs/Microsoft.Maui.Controls.resources => 2
	i64 u0x70e99f48c05cb921, ; 208: tr/Microsoft.Maui.Controls.resources.dll => 28
	i64 u0x70fd3deda22442d2, ; 209: lib-nb-Microsoft.Maui.Controls.resources.dll.so => 18
	i64 u0x71a495ea3761dde8, ; 210: lib-it-Microsoft.Maui.Controls.resources.dll.so => 14
	i64 u0x71ad672adbe48f35, ; 211: System.ComponentModel.Primitives.dll => 95
	i64 u0x725f5a9e82a45c81, ; 212: System.Security.Cryptography.Encoding => 136
	i64 u0x72b1fb4109e08d7b, ; 213: lib-hr-Microsoft.Maui.Controls.resources.dll.so => 11
	i64 u0x73e4ce94e2eb6ffc, ; 214: lib_System.Memory.dll.so => 112
	i64 u0x755a91767330b3d4, ; 215: lib_Microsoft.Extensions.Configuration.dll.so => 40
	i64 u0x76012e7334db86e5, ; 216: lib_Xamarin.AndroidX.SavedState.dll.so => 79
	i64 u0x76ca07b878f44da0, ; 217: System.Runtime.Numerics.dll => 130
	i64 u0x777b4ed432c1e61e, ; 218: K4os.Compression.LZ4.Streams => 38
	i64 u0x780bc73597a503a9, ; 219: lib-ms-Microsoft.Maui.Controls.resources.dll.so => 17
	i64 u0x783606d1e53e7a1a, ; 220: th/Microsoft.Maui.Controls.resources.dll => 27
	i64 u0x7841c47b741b9f64, ; 221: System.Security.Permissions => 57
	i64 u0x78a45e51311409b6, ; 222: Xamarin.AndroidX.Fragment.dll => 68
	i64 u0x79e56fd88cdb3352, ; 223: Fitxar.dll => 88
	i64 u0x7adb8da2ac89b647, ; 224: fi/Microsoft.Maui.Controls.resources.dll => 7
	i64 u0x7bef86a4335c4870, ; 225: System.ComponentModel.TypeConverter => 96
	i64 u0x7c0820144cd34d6a, ; 226: sk/Microsoft.Maui.Controls.resources.dll => 25
	i64 u0x7c2a0bd1e0f988fc, ; 227: lib-de-Microsoft.Maui.Controls.resources.dll.so => 4
	i64 u0x7c41d387501568ba, ; 228: System.Net.WebClient.dll => 120
	i64 u0x7d649b75d580bb42, ; 229: ms/Microsoft.Maui.Controls.resources.dll => 17
	i64 u0x7d8ee2bdc8e3aad1, ; 230: System.Numerics.Vectors => 122
	i64 u0x7dfc3d6d9d8d7b70, ; 231: System.Collections => 93
	i64 u0x7e1f8f575a3599cb, ; 232: BouncyCastle.Cryptography.dll => 35
	i64 u0x7e302e110e1e1346, ; 233: lib_System.Security.Claims.dll.so => 133
	i64 u0x7e946809d6008ef2, ; 234: lib_System.ObjectModel.dll.so => 123
	i64 u0x7ecc13347c8fd849, ; 235: lib_System.ComponentModel.dll.so => 97
	i64 u0x7f00ddd9b9ca5a13, ; 236: Xamarin.AndroidX.ViewPager.dll => 81
	i64 u0x7f9351cd44b1273f, ; 237: Microsoft.Extensions.Configuration.Abstractions => 41
	i64 u0x7fbd557c99b3ce6f, ; 238: lib_Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so => 70
	i64 u0x812c069d5cdecc17, ; 239: System.dll => 154
	i64 u0x81ab745f6c0f5ce6, ; 240: zh-Hant/Microsoft.Maui.Controls.resources => 33
	i64 u0x82075fdf49c26af2, ; 241: ZstdSharp => 87
	i64 u0x8277f2be6b5ce05f, ; 242: Xamarin.AndroidX.AppCompat => 59
	i64 u0x828f06563b30bc50, ; 243: lib_Xamarin.AndroidX.CardView.dll.so => 61
	i64 u0x82df8f5532a10c59, ; 244: lib_System.Drawing.dll.so => 105
	i64 u0x82f6403342e12049, ; 245: uk/Microsoft.Maui.Controls.resources => 29
	i64 u0x83c14ba66c8e2b8c, ; 246: zh-Hans/Microsoft.Maui.Controls.resources => 32
	i64 u0x86a909228dc7657b, ; 247: lib-zh-Hant-Microsoft.Maui.Controls.resources.dll.so => 33
	i64 u0x86b3e00c36b84509, ; 248: Microsoft.Extensions.Configuration.dll => 40
	i64 u0x87c69b87d9283884, ; 249: lib_System.Threading.Thread.dll.so => 147
	i64 u0x87f6569b25707834, ; 250: System.IO.Compression.Brotli.dll => 107
	i64 u0x8842b3a5d2d3fb36, ; 251: Microsoft.Maui.Essentials => 51
	i64 u0x88bda98e0cffb7a9, ; 252: lib_Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so => 85
	i64 u0x897a606c9e39c75f, ; 253: lib_System.ComponentModel.Primitives.dll.so => 95
	i64 u0x8ad229ea26432ee2, ; 254: Xamarin.AndroidX.Loader => 73
	i64 u0x8b4ff5d0fdd5faa1, ; 255: lib_System.Diagnostics.DiagnosticSource.dll.so => 100
	i64 u0x8b541d476eb3774c, ; 256: System.Security.Principal.Windows => 140
	i64 u0x8b8d01333a96d0b5, ; 257: System.Diagnostics.Process.dll => 101
	i64 u0x8b9ceca7acae3451, ; 258: lib-he-Microsoft.Maui.Controls.resources.dll.so => 9
	i64 u0x8c1bafb2ed25af5b, ; 259: K4os.Compression.LZ4.Streams.dll => 38
	i64 u0x8cdfdb4ce85fb925, ; 260: lib_System.Security.Principal.Windows.dll.so => 140
	i64 u0x8d0f420977c2c1c7, ; 261: Xamarin.AndroidX.CursorAdapter.dll => 65
	i64 u0x8d7b8ab4b3310ead, ; 262: System.Threading => 149
	i64 u0x8da188285aadfe8e, ; 263: System.Collections.Concurrent => 90
	i64 u0x8ed3cdd722b4d782, ; 264: System.Diagnostics.EventLog => 55
	i64 u0x8ed807bfe9858dfc, ; 265: Xamarin.AndroidX.Navigation.Common => 74
	i64 u0x8ee08b8194a30f48, ; 266: lib-hi-Microsoft.Maui.Controls.resources.dll.so => 10
	i64 u0x8ef7601039857a44, ; 267: lib-ro-Microsoft.Maui.Controls.resources.dll.so => 23
	i64 u0x8f32c6f611f6ffab, ; 268: pt/Microsoft.Maui.Controls.resources.dll => 22
	i64 u0x8f8829d21c8985a4, ; 269: lib-pt-BR-Microsoft.Maui.Controls.resources.dll.so => 21
	i64 u0x90263f8448b8f572, ; 270: lib_System.Diagnostics.TraceSource.dll.so => 103
	i64 u0x903101b46fb73a04, ; 271: _Microsoft.Android.Resource.Designer => 34
	i64 u0x90393bd4865292f3, ; 272: lib_System.IO.Compression.dll.so => 108
	i64 u0x90634f86c5ebe2b5, ; 273: Xamarin.AndroidX.Lifecycle.ViewModel.Android => 71
	i64 u0x907b636704ad79ef, ; 274: lib_Microsoft.Maui.Controls.Xaml.dll.so => 49
	i64 u0x91418dc638b29e68, ; 275: lib_Xamarin.AndroidX.CustomView.dll.so => 66
	i64 u0x9157bd523cd7ed36, ; 276: lib_System.Text.Json.dll.so => 144
	i64 u0x91a74f07b30d37e2, ; 277: System.Linq.dll => 111
	i64 u0x91fa41a87223399f, ; 278: ca/Microsoft.Maui.Controls.resources.dll => 1
	i64 u0x93cfa73ab28d6e35, ; 279: ms/Microsoft.Maui.Controls.resources => 17
	i64 u0x944077d8ca3c6580, ; 280: System.IO.Compression.dll => 108
	i64 u0x967fc325e09bfa8c, ; 281: es/Microsoft.Maui.Controls.resources => 6
	i64 u0x9732d8dbddea3d9a, ; 282: id/Microsoft.Maui.Controls.resources => 13
	i64 u0x978be80e5210d31b, ; 283: Microsoft.Maui.Graphics.dll => 52
	i64 u0x97b8c771ea3e4220, ; 284: System.ComponentModel.dll => 97
	i64 u0x97e144c9d3c6976e, ; 285: System.Collections.Concurrent.dll => 90
	i64 u0x991d510397f92d9d, ; 286: System.Linq.Expressions => 110
	i64 u0x99868af5d93ecaeb, ; 287: lib_K4os.Hash.xxHash.dll.so => 39
	i64 u0x99a00ca5270c6878, ; 288: Xamarin.AndroidX.Navigation.Runtime => 76
	i64 u0x99cdc6d1f2d3a72f, ; 289: ko/Microsoft.Maui.Controls.resources.dll => 16
	i64 u0x9b211a749105beac, ; 290: System.Transactions.Local => 150
	i64 u0x9c244ac7cda32d26, ; 291: System.Security.Cryptography.X509Certificates.dll => 138
	i64 u0x9d5dbcf5a48583fe, ; 292: lib_Xamarin.AndroidX.Activity.dll.so => 58
	i64 u0x9d74dee1a7725f34, ; 293: Microsoft.Extensions.Configuration.Abstractions.dll => 41
	i64 u0x9e4534b6adaf6e84, ; 294: nl/Microsoft.Maui.Controls.resources => 19
	i64 u0x9eaf1efdf6f7267e, ; 295: Xamarin.AndroidX.Navigation.Common.dll => 74
	i64 u0x9ef542cf1f78c506, ; 296: Xamarin.AndroidX.Lifecycle.LiveData.Core => 70
	i64 u0xa0d8259f4cc284ec, ; 297: lib_System.Security.Cryptography.dll.so => 139
	i64 u0xa1440773ee9d341e, ; 298: Xamarin.Google.Android.Material => 83
	i64 u0xa1b9d7c27f47219f, ; 299: Xamarin.AndroidX.Navigation.UI.dll => 77
	i64 u0xa2572680829d2c7c, ; 300: System.IO.Pipelines.dll => 109
	i64 u0xa46aa1eaa214539b, ; 301: ko/Microsoft.Maui.Controls.resources => 16
	i64 u0xa4edc8f2ceae241a, ; 302: System.Data.Common.dll => 99
	i64 u0xa5494f40f128ce6a, ; 303: System.Runtime.Serialization.Formatters.dll => 131
	i64 u0xa5ce5c755bde8cb8, ; 304: lib_System.Security.Cryptography.Csp.dll.so => 135
	i64 u0xa5e599d1e0524750, ; 305: System.Numerics.Vectors.dll => 122
	i64 u0xa5f1ba49b85dd355, ; 306: System.Security.Cryptography.dll => 139
	i64 u0xa61975a5a37873ea, ; 307: lib_System.Xml.XmlSerializer.dll.so => 153
	i64 u0xa64476a892d76457, ; 308: lib_MySql.Data.dll.so => 53
	i64 u0xa67dbee13e1df9ca, ; 309: Xamarin.AndroidX.SavedState.dll => 79
	i64 u0xa68a420042bb9b1f, ; 310: Xamarin.AndroidX.DrawerLayout.dll => 67
	i64 u0xa763fbb98df8d9fb, ; 311: lib_Microsoft.Win32.Primitives.dll.so => 89
	i64 u0xa78ce3745383236a, ; 312: Xamarin.AndroidX.Lifecycle.Common.Jvm => 69
	i64 u0xa7c31b56b4dc7b33, ; 313: hu/Microsoft.Maui.Controls.resources => 12
	i64 u0xa8e602d25944dbbd, ; 314: lib_Fitxar.dll.so => 88
	i64 u0xaa2219c8e3449ff5, ; 315: Microsoft.Extensions.Logging.Abstractions => 45
	i64 u0xaa443ac34067eeef, ; 316: System.Private.Xml.dll => 125
	i64 u0xaa52de307ef5d1dd, ; 317: System.Net.Http => 113
	i64 u0xaaaf86367285a918, ; 318: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 43
	i64 u0xaaf84bb3f052a265, ; 319: el/Microsoft.Maui.Controls.resources => 5
	i64 u0xab9c1b2687d86b0b, ; 320: lib_System.Linq.Expressions.dll.so => 110
	i64 u0xac2af3fa195a15ce, ; 321: System.Runtime.Numerics => 130
	i64 u0xac5376a2a538dc10, ; 322: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 70
	i64 u0xac65e40f62b6b90e, ; 323: Google.Protobuf => 36
	i64 u0xac79c7e46047ad98, ; 324: System.Security.Principal.Windows.dll => 140
	i64 u0xacd46e002c3ccb97, ; 325: ro/Microsoft.Maui.Controls.resources => 23
	i64 u0xacf42eea7ef9cd12, ; 326: System.Threading.Channels => 146
	i64 u0xad89c07347f1bad6, ; 327: nl/Microsoft.Maui.Controls.resources.dll => 19
	i64 u0xadbb53caf78a79d2, ; 328: System.Web.HttpUtility => 151
	i64 u0xadc90ab061a9e6e4, ; 329: System.ComponentModel.TypeConverter.dll => 96
	i64 u0xadf511667bef3595, ; 330: System.Net.Security => 118
	i64 u0xae0aaa94fdcfce0f, ; 331: System.ComponentModel.EventBasedAsync.dll => 94
	i64 u0xae282bcd03739de7, ; 332: Java.Interop => 156
	i64 u0xae53579c90db1107, ; 333: System.ObjectModel.dll => 123
	i64 u0xafe29f45095518e7, ; 334: lib_Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll.so => 72
	i64 u0xb05cc42cd94c6d9d, ; 335: lib-sv-Microsoft.Maui.Controls.resources.dll.so => 26
	i64 u0xb220631954820169, ; 336: System.Text.RegularExpressions => 145
	i64 u0xb2376e1dbf8b4ed7, ; 337: System.Security.Cryptography.Csp => 135
	i64 u0xb2a3f67f3bf29fce, ; 338: da/Microsoft.Maui.Controls.resources => 3
	i64 u0xb398860d6ed7ba2f, ; 339: System.Security.Cryptography.ProtectedData => 56
	i64 u0xb3f0a0fcda8d3ebc, ; 340: Xamarin.AndroidX.CardView => 61
	i64 u0xb46be1aa6d4fff93, ; 341: hi/Microsoft.Maui.Controls.resources => 10
	i64 u0xb477491be13109d8, ; 342: ar/Microsoft.Maui.Controls.resources => 0
	i64 u0xb4bd7015ecee9d86, ; 343: System.IO.Pipelines => 109
	i64 u0xb5c7fcdafbc67ee4, ; 344: Microsoft.Extensions.Logging.Abstractions.dll => 45
	i64 u0xb5ea31d5244c6626, ; 345: System.Threading.ThreadPool.dll => 148
	i64 u0xb7212c4683a94afe, ; 346: System.Drawing.Primitives => 104
	i64 u0xb7b7753d1f319409, ; 347: sv/Microsoft.Maui.Controls.resources => 26
	i64 u0xb81a2c6e0aee50fe, ; 348: lib_System.Private.CoreLib.dll.so => 155
	i64 u0xb9f64d3b230def68, ; 349: lib-pt-Microsoft.Maui.Controls.resources.dll.so => 22
	i64 u0xb9fc3c8a556e3691, ; 350: ja/Microsoft.Maui.Controls.resources => 15
	i64 u0xba48785529705af9, ; 351: System.Collections.dll => 93
	i64 u0xbadbc0a44214b54e, ; 352: K4os.Compression.LZ4 => 37
	i64 u0xbb65706fde942ce3, ; 353: System.Net.Sockets => 119
	i64 u0xbbd180354b67271a, ; 354: System.Runtime.Serialization.Formatters => 131
	i64 u0xbd0e2c0d55246576, ; 355: System.Net.Http.dll => 113
	i64 u0xbd437a2cdb333d0d, ; 356: Xamarin.AndroidX.ViewPager2 => 82
	i64 u0xbd877b14d0b56392, ; 357: System.Runtime.Intrinsics.dll => 128
	i64 u0xbee38d4a88835966, ; 358: Xamarin.AndroidX.AppCompat.AppCompatResources => 60
	i64 u0xc040a4ab55817f58, ; 359: ar/Microsoft.Maui.Controls.resources.dll => 0
	i64 u0xc0d928351ab5ca77, ; 360: System.Console.dll => 98
	i64 u0xc0f5a221a9383aea, ; 361: System.Runtime.Intrinsics => 128
	i64 u0xc12b8b3afa48329c, ; 362: lib_System.Linq.dll.so => 111
	i64 u0xc1ff9ae3cdb6e1e6, ; 363: Xamarin.AndroidX.Activity.dll => 58
	i64 u0xc2260e1da1054ac1, ; 364: lib_BouncyCastle.Cryptography.dll.so => 35
	i64 u0xc28c50f32f81cc73, ; 365: ja/Microsoft.Maui.Controls.resources.dll => 15
	i64 u0xc2bcfec99f69365e, ; 366: Xamarin.AndroidX.ViewPager2.dll => 82
	i64 u0xc4d3858ed4d08512, ; 367: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 72
	i64 u0xc50fded0ded1418c, ; 368: lib_System.ComponentModel.TypeConverter.dll.so => 96
	i64 u0xc519125d6bc8fb11, ; 369: lib_System.Net.Requests.dll.so => 117
	i64 u0xc5293b19e4dc230e, ; 370: Xamarin.AndroidX.Navigation.Fragment => 75
	i64 u0xc5325b2fcb37446f, ; 371: lib_System.Private.Xml.dll.so => 125
	i64 u0xc5a0f4b95a699af7, ; 372: lib_System.Private.Uri.dll.so => 124
	i64 u0xc5cdcd5b6277579e, ; 373: lib_System.Security.Cryptography.Algorithms.dll.so => 134
	i64 u0xc6a4665a88c57225, ; 374: lib_ZstdSharp.dll.so => 87
	i64 u0xc7c01e7d7c93a110, ; 375: System.Text.Encoding.Extensions.dll => 142
	i64 u0xc7ce851898a4548e, ; 376: lib_System.Web.HttpUtility.dll.so => 151
	i64 u0xc858a28d9ee5a6c5, ; 377: lib_System.Collections.Specialized.dll.so => 92
	i64 u0xc9c62c8f354ac568, ; 378: lib_System.Diagnostics.TextWriterTraceListener.dll.so => 102
	i64 u0xca3a723e7342c5b6, ; 379: lib-tr-Microsoft.Maui.Controls.resources.dll.so => 28
	i64 u0xcab3493c70141c2d, ; 380: pl/Microsoft.Maui.Controls.resources => 20
	i64 u0xcacfddc9f7c6de76, ; 381: ro/Microsoft.Maui.Controls.resources.dll => 23
	i64 u0xcbd4fdd9cef4a294, ; 382: lib__Microsoft.Android.Resource.Designer.dll.so => 34
	i64 u0xcc2876b32ef2794c, ; 383: lib_System.Text.RegularExpressions.dll.so => 145
	i64 u0xcc5c3bb714c4561e, ; 384: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 85
	i64 u0xcc76886e09b88260, ; 385: Xamarin.KotlinX.Serialization.Core.Jvm.dll => 86
	i64 u0xccf25c4b634ccd3a, ; 386: zh-Hans/Microsoft.Maui.Controls.resources.dll => 32
	i64 u0xcd10a42808629144, ; 387: System.Net.Requests => 117
	i64 u0xcdd0c48b6937b21c, ; 388: Xamarin.AndroidX.SwipeRefreshLayout => 80
	i64 u0xcf23d8093f3ceadf, ; 389: System.Diagnostics.DiagnosticSource.dll => 100
	i64 u0xd0de8a113e976700, ; 390: System.Diagnostics.TextWriterTraceListener => 102
	i64 u0xd1194e1d8a8de83c, ; 391: lib_Xamarin.AndroidX.Lifecycle.Common.Jvm.dll.so => 69
	i64 u0xd22a0c4630f2fe66, ; 392: lib_System.Security.Cryptography.ProtectedData.dll.so => 56
	i64 u0xd333d0af9e423810, ; 393: System.Runtime.InteropServices => 127
	i64 u0xd33a415cb4278969, ; 394: System.Security.Cryptography.Encoding.dll => 136
	i64 u0xd3426d966bb704f5, ; 395: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 60
	i64 u0xd3651b6fc3125825, ; 396: System.Private.Uri.dll => 124
	i64 u0xd373685349b1fe8b, ; 397: Microsoft.Extensions.Logging.dll => 44
	i64 u0xd3e4c8d6a2d5d470, ; 398: it/Microsoft.Maui.Controls.resources => 14
	i64 u0xd4645626dffec99d, ; 399: lib_Microsoft.Extensions.DependencyInjection.Abstractions.dll.so => 43
	i64 u0xd5507e11a2b2839f, ; 400: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 72
	i64 u0xd6694f8359737e4e, ; 401: Xamarin.AndroidX.SavedState => 79
	i64 u0xd6d21782156bc35b, ; 402: Xamarin.AndroidX.SwipeRefreshLayout.dll => 80
	i64 u0xd72329819cbbbc44, ; 403: lib_Microsoft.Extensions.Configuration.Abstractions.dll.so => 41
	i64 u0xd72c760af136e863, ; 404: System.Xml.XmlSerializer.dll => 153
	i64 u0xd7b3764ada9d341d, ; 405: lib_Microsoft.Extensions.Logging.Abstractions.dll.so => 45
	i64 u0xd9e245a1762ddad5, ; 406: BouncyCastle.Cryptography => 35
	i64 u0xda1dfa4c534a9251, ; 407: Microsoft.Extensions.DependencyInjection => 42
	i64 u0xdad05a11827959a3, ; 408: System.Collections.NonGeneric.dll => 91
	i64 u0xdb5383ab5865c007, ; 409: lib-vi-Microsoft.Maui.Controls.resources.dll.so => 30
	i64 u0xdbeda89f832aa805, ; 410: vi/Microsoft.Maui.Controls.resources.dll => 30
	i64 u0xdbf2a779fbc3ac31, ; 411: System.Transactions.Local.dll => 150
	i64 u0xdbf9607a441b4505, ; 412: System.Linq => 111
	i64 u0xdc75032002d1a212, ; 413: lib_System.Transactions.Local.dll.so => 150
	i64 u0xdce2c53525640bf3, ; 414: Microsoft.Extensions.Logging => 44
	i64 u0xdd2b722d78ef5f43, ; 415: System.Runtime.dll => 132
	i64 u0xdd67031857c72f96, ; 416: lib_System.Text.Encodings.Web.dll.so => 143
	i64 u0xdde30e6b77aa6f6c, ; 417: lib-zh-Hans-Microsoft.Maui.Controls.resources.dll.so => 32
	i64 u0xde8769ebda7d8647, ; 418: hr/Microsoft.Maui.Controls.resources.dll => 11
	i64 u0xdf35b6d818902893, ; 419: K4os.Hash.xxHash.dll => 39
	i64 u0xe0142572c095a480, ; 420: Xamarin.AndroidX.AppCompat.dll => 59
	i64 u0xe02f89350ec78051, ; 421: Xamarin.AndroidX.CoordinatorLayout.dll => 63
	i64 u0xe10b760bb1462e7a, ; 422: lib_System.Security.Cryptography.Primitives.dll.so => 137
	i64 u0xe192a588d4410686, ; 423: lib_System.IO.Pipelines.dll.so => 109
	i64 u0xe1a08bd3fa539e0d, ; 424: System.Runtime.Loader => 129
	i64 u0xe1ecfdb7fff86067, ; 425: System.Net.Security.dll => 118
	i64 u0xe22fa4c9c645db62, ; 426: System.Diagnostics.TextWriterTraceListener.dll => 102
	i64 u0xe2420585aeceb728, ; 427: System.Net.Requests.dll => 117
	i64 u0xe29b73bc11392966, ; 428: lib-id-Microsoft.Maui.Controls.resources.dll.so => 13
	i64 u0xe2e426c7714fa0bc, ; 429: Microsoft.Win32.Primitives.dll => 89
	i64 u0xe3811d68d4fe8463, ; 430: pt-BR/Microsoft.Maui.Controls.resources.dll => 21
	i64 u0xe3b7cbae5ad66c75, ; 431: lib_System.Security.Cryptography.Encoding.dll.so => 136
	i64 u0xe494f7ced4ecd10a, ; 432: hu/Microsoft.Maui.Controls.resources.dll => 12
	i64 u0xe4a9b1e40d1e8917, ; 433: lib-fi-Microsoft.Maui.Controls.resources.dll.so => 7
	i64 u0xe5434e8a119ceb69, ; 434: lib_Mono.Android.dll.so => 158
	i64 u0xe57d22ca4aeb4900, ; 435: System.Configuration.ConfigurationManager => 54
	i64 u0xe89a2a9ef110899b, ; 436: System.Drawing.dll => 105
	i64 u0xed6ef763c6fb395f, ; 437: System.Diagnostics.EventLog.dll => 55
	i64 u0xedc4817167106c23, ; 438: System.Net.Sockets.dll => 119
	i64 u0xedc632067fb20ff3, ; 439: System.Memory.dll => 112
	i64 u0xedc8e4ca71a02a8b, ; 440: Xamarin.AndroidX.Navigation.Runtime.dll => 76
	i64 u0xee81f5b3f1c4f83b, ; 441: System.Threading.ThreadPool => 148
	i64 u0xeeb7ebb80150501b, ; 442: lib_Xamarin.AndroidX.Collection.Jvm.dll.so => 62
	i64 u0xef03b1b5a04e9709, ; 443: System.Text.Encoding.CodePages.dll => 141
	i64 u0xef72742e1bcca27a, ; 444: Microsoft.Maui.Essentials.dll => 51
	i64 u0xefec0b7fdc57ec42, ; 445: Xamarin.AndroidX.Activity => 58
	i64 u0xf00c29406ea45e19, ; 446: es/Microsoft.Maui.Controls.resources.dll => 6
	i64 u0xf09e47b6ae914f6e, ; 447: System.Net.NameResolution => 114
	i64 u0xf0de2537ee19c6ca, ; 448: lib_System.Net.WebHeaderCollection.dll.so => 121
	i64 u0xf11b621fc87b983f, ; 449: Microsoft.Maui.Controls.Xaml.dll => 49
	i64 u0xf1c4b4005493d871, ; 450: System.Formats.Asn1.dll => 106
	i64 u0xf238bd79489d3a96, ; 451: lib-nl-Microsoft.Maui.Controls.resources.dll.so => 19
	i64 u0xf37221fda4ef8830, ; 452: lib_Xamarin.Google.Android.Material.dll.so => 83
	i64 u0xf3ddfe05336abf29, ; 453: System => 154
	i64 u0xf4c1dd70a5496a17, ; 454: System.IO.Compression => 108
	i64 u0xf5fc7602fe27b333, ; 455: System.Net.WebHeaderCollection => 121
	i64 u0xf6077741019d7428, ; 456: Xamarin.AndroidX.CoordinatorLayout => 63
	i64 u0xf77b20923f07c667, ; 457: de/Microsoft.Maui.Controls.resources.dll => 4
	i64 u0xf7e2cac4c45067b3, ; 458: lib_System.Numerics.Vectors.dll.so => 122
	i64 u0xf7e74930e0e3d214, ; 459: zh-HK/Microsoft.Maui.Controls.resources.dll => 31
	i64 u0xf84773b5c81e3cef, ; 460: lib-uk-Microsoft.Maui.Controls.resources.dll.so => 29
	i64 u0xf8e045dc345b2ea3, ; 461: lib_Xamarin.AndroidX.RecyclerView.dll.so => 78
	i64 u0xf915dc29808193a1, ; 462: System.Web.HttpUtility.dll => 151
	i64 u0xf96c777a2a0686f4, ; 463: hi/Microsoft.Maui.Controls.resources.dll => 10
	i64 u0xf9eec5bb3a6aedc6, ; 464: Microsoft.Extensions.Options => 46
	i64 u0xfa2fdb27e8a2c8e8, ; 465: System.ComponentModel.EventBasedAsync => 94
	i64 u0xfa3f278f288b0e84, ; 466: lib_System.Net.Security.dll.so => 118
	i64 u0xfa5ed7226d978949, ; 467: lib-ar-Microsoft.Maui.Controls.resources.dll.so => 0
	i64 u0xfa645d91e9fc4cba, ; 468: System.Threading.Thread => 147
	i64 u0xfbad3e4ce4b98145, ; 469: System.Security.Cryptography.X509Certificates => 138
	i64 u0xfbf0a31c9fc34bc4, ; 470: lib_System.Net.Http.dll.so => 113
	i64 u0xfc6b7527cc280b3f, ; 471: lib_System.Runtime.Serialization.Formatters.dll.so => 131
	i64 u0xfc719aec26adf9d9, ; 472: Xamarin.AndroidX.Navigation.Fragment.dll => 75
	i64 u0xfd22f00870e40ae0, ; 473: lib_Xamarin.AndroidX.DrawerLayout.dll.so => 67
	i64 u0xfd536c702f64dc47, ; 474: System.Text.Encoding.Extensions => 142
	i64 u0xfd583f7657b6a1cb, ; 475: Xamarin.AndroidX.Fragment => 68
	i64 u0xfeae9952cf03b8cb ; 476: tr/Microsoft.Maui.Controls.resources => 28
], align 16

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [477 x i32] [
	i32 80, i32 76, i32 157, i32 59, i32 24, i32 2, i32 30, i32 116,
	i32 78, i32 93, i32 50, i32 126, i32 31, i32 62, i32 24, i32 91,
	i32 67, i32 46, i32 91, i32 139, i32 146, i32 25, i32 86, i32 81,
	i32 21, i32 158, i32 51, i32 114, i32 66, i32 107, i32 137, i32 37,
	i32 78, i32 8, i32 156, i32 9, i32 43, i32 89, i32 55, i32 134,
	i32 12, i32 143, i32 86, i32 120, i32 18, i32 133, i32 90, i32 154,
	i32 27, i32 157, i32 36, i32 77, i32 16, i32 46, i32 153, i32 120,
	i32 107, i32 57, i32 101, i32 132, i32 27, i32 37, i32 147, i32 98,
	i32 64, i32 8, i32 84, i32 47, i32 13, i32 11, i32 156, i32 116,
	i32 29, i32 115, i32 103, i32 7, i32 145, i32 106, i32 33, i32 20,
	i32 141, i32 149, i32 26, i32 144, i32 5, i32 101, i32 152, i32 68,
	i32 34, i32 61, i32 104, i32 8, i32 152, i32 6, i32 119, i32 50,
	i32 2, i32 48, i32 82, i32 40, i32 128, i32 126, i32 66, i32 114,
	i32 54, i32 81, i32 1, i32 137, i32 53, i32 142, i32 138, i32 84,
	i32 148, i32 64, i32 36, i32 53, i32 74, i32 54, i32 60, i32 158,
	i32 20, i32 84, i32 103, i32 24, i32 22, i32 57, i32 123, i32 77,
	i32 144, i32 73, i32 115, i32 110, i32 125, i32 129, i32 14, i32 73,
	i32 157, i32 141, i32 146, i32 1, i32 48, i32 71, i32 105, i32 116,
	i32 99, i32 64, i32 52, i32 25, i32 115, i32 31, i32 133, i32 132,
	i32 69, i32 92, i32 124, i32 155, i32 100, i32 15, i32 42, i32 63,
	i32 149, i32 97, i32 3, i32 39, i32 44, i32 121, i32 127, i32 62,
	i32 92, i32 143, i32 95, i32 135, i32 152, i32 99, i32 5, i32 126,
	i32 42, i32 85, i32 112, i32 38, i32 49, i32 4, i32 129, i32 155,
	i32 83, i32 134, i32 87, i32 48, i32 130, i32 98, i32 71, i32 65,
	i32 3, i32 104, i32 88, i32 106, i32 9, i32 127, i32 18, i32 56,
	i32 52, i32 94, i32 47, i32 65, i32 47, i32 75, i32 50, i32 2,
	i32 28, i32 18, i32 14, i32 95, i32 136, i32 11, i32 112, i32 40,
	i32 79, i32 130, i32 38, i32 17, i32 27, i32 57, i32 68, i32 88,
	i32 7, i32 96, i32 25, i32 4, i32 120, i32 17, i32 122, i32 93,
	i32 35, i32 133, i32 123, i32 97, i32 81, i32 41, i32 70, i32 154,
	i32 33, i32 87, i32 59, i32 61, i32 105, i32 29, i32 32, i32 33,
	i32 40, i32 147, i32 107, i32 51, i32 85, i32 95, i32 73, i32 100,
	i32 140, i32 101, i32 9, i32 38, i32 140, i32 65, i32 149, i32 90,
	i32 55, i32 74, i32 10, i32 23, i32 22, i32 21, i32 103, i32 34,
	i32 108, i32 71, i32 49, i32 66, i32 144, i32 111, i32 1, i32 17,
	i32 108, i32 6, i32 13, i32 52, i32 97, i32 90, i32 110, i32 39,
	i32 76, i32 16, i32 150, i32 138, i32 58, i32 41, i32 19, i32 74,
	i32 70, i32 139, i32 83, i32 77, i32 109, i32 16, i32 99, i32 131,
	i32 135, i32 122, i32 139, i32 153, i32 53, i32 79, i32 67, i32 89,
	i32 69, i32 12, i32 88, i32 45, i32 125, i32 113, i32 43, i32 5,
	i32 110, i32 130, i32 70, i32 36, i32 140, i32 23, i32 146, i32 19,
	i32 151, i32 96, i32 118, i32 94, i32 156, i32 123, i32 72, i32 26,
	i32 145, i32 135, i32 3, i32 56, i32 61, i32 10, i32 0, i32 109,
	i32 45, i32 148, i32 104, i32 26, i32 155, i32 22, i32 15, i32 93,
	i32 37, i32 119, i32 131, i32 113, i32 82, i32 128, i32 60, i32 0,
	i32 98, i32 128, i32 111, i32 58, i32 35, i32 15, i32 82, i32 72,
	i32 96, i32 117, i32 75, i32 125, i32 124, i32 134, i32 87, i32 142,
	i32 151, i32 92, i32 102, i32 28, i32 20, i32 23, i32 34, i32 145,
	i32 85, i32 86, i32 32, i32 117, i32 80, i32 100, i32 102, i32 69,
	i32 56, i32 127, i32 136, i32 60, i32 124, i32 44, i32 14, i32 43,
	i32 72, i32 79, i32 80, i32 41, i32 153, i32 45, i32 35, i32 42,
	i32 91, i32 30, i32 30, i32 150, i32 111, i32 150, i32 44, i32 132,
	i32 143, i32 32, i32 11, i32 39, i32 59, i32 63, i32 137, i32 109,
	i32 129, i32 118, i32 102, i32 117, i32 13, i32 89, i32 21, i32 136,
	i32 12, i32 7, i32 158, i32 54, i32 105, i32 55, i32 119, i32 112,
	i32 76, i32 148, i32 62, i32 141, i32 51, i32 58, i32 6, i32 114,
	i32 121, i32 49, i32 106, i32 19, i32 83, i32 154, i32 108, i32 121,
	i32 63, i32 4, i32 122, i32 31, i32 29, i32 78, i32 151, i32 10,
	i32 46, i32 94, i32 118, i32 0, i32 147, i32 138, i32 113, i32 131,
	i32 75, i32 67, i32 142, i32 68, i32 28
], align 16

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 u0x0000000000000000, ; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: memory(write, argmem: none, inaccessiblemem: none) "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 16

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { memory(write, argmem: none, inaccessiblemem: none) "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!".NET for Android remotes/origin/release/9.0.1xx @ 0ccdc57cf7fc59bd3f6cbf900c9cdbebadfe4609"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
