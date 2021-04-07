#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <stdint.h>
#include <limits>



// System.Void
struct Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5;



IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object


// System.ValueType
struct  ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52  : public RuntimeObject
{
public:

public:
};

// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_com
{
};

// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};


// System.Void
struct  Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5__padding[1];
	};

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

extern "C" void DEFAULT_CALL ReversePInvokeWrapper_OSSpecificSynchronizationContext_InvocationEntry_m0045E44F7E960D6B4A864D5206D4116249C09BB0(intptr_t ___arg0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosBanner_UnityAdsBannerDidShow_mDB64E458C30D007276D53173986276764C7B4591(char* ___placementId0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosBanner_UnityAdsBannerDidHide_m2D9B1C4E23A7C516C0C6AA3E3E78D6F4C8F8CB61(char* ___placementId0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosBanner_UnityAdsBannerClick_m9DDD7785E0ED0D952C973DB1F3C1A96B89D29660(char* ___placementId0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosBanner_UnityAdsBannerDidError_m4D2F6AB970DD9BDF7CCD5493D3E68A4F72C2AB69(char* ___message0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosBanner_UnityAdsBannerDidUnload_m21A59DD65BFEC00759582DE593B70B542A9C5D19(char* ___placementId0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosBanner_UnityAdsBannerDidLoad_m88E63E83A4731097E3AD6B23CE6C9D15C31DB855(char* ___placementId0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosInitializationListener_OnInitializationComplete_mCE07918F7BBF79FCA0F78C557453D91A747C63C9(intptr_t ___ptr0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosInitializationListener_OnInitializationFailed_mD345F0A652BAF2869915CA3CB94D80CBBFF6E1B2(intptr_t ___ptr0, int32_t ___error1, char* ___message2);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosLoadListener_OnLoadSuccess_m8727A9C87753DA3ACEE846977DF048749DA79AA3(intptr_t ___ptr0, char* ___placementId1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosLoadListener_OnLoadFailure_mF25796FD82FC8C08F4F521E575A09A4AC7D36357(intptr_t ___ptr0, char* ___placementId1, int32_t ___error2, char* ___message3);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosPlatform_UnityAdsReady_mE78B536B6B031C4337A32C4A352959D425C7CC37(char* ___placementId0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosPlatform_UnityAdsDidError_m2FBE6272AB73BFACFB07D2E316A5401969AD5B5D(int64_t ___rawError0, char* ___message1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosPlatform_UnityAdsDidStart_m65935F1B8435546388E195950546F3AA5FA120B6(char* ___placementId0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosPlatform_UnityAdsDidFinish_m13B1C7444617B23A20E94AAC701F8130C1168A63(char* ___placementId0, int64_t ___rawShowResult1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosShowListener_OnShowFailure_mB7664BDA20F0A0094D82818A2572ADCAF8527FBB(intptr_t ___ptr0, char* ___placementId1, int32_t ___error2, char* ___message3);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosShowListener_OnShowStart_m2BD70571938B2025172025054CD63E90192856FE(intptr_t ___ptr0, char* ___placementId1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosShowListener_OnShowClick_m38A42EC0E0FAA273339E46E2D9A4B8E9ADFAE5B9(intptr_t ___ptr0, char* ___placementId1);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IosShowListener_OnShowComplete_m28A5C41699323E6184CD0FEDC851010046C6056B(intptr_t ___ptr0, char* ___placementId1, int32_t ___completionState2);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_PurchasingPlatform_UnityAdsDidInitiatePurchasingCommand_m85ED160ECB9DBD1CC7D2731E0D090AFC451EDA81(char* ___eventString0);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_PurchasingPlatform_UnityAdsPurchasingGetProductCatalog_mB34A1BA39F821C040DCF65C8099AA4E458DBEE48();
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_PurchasingPlatform_UnityAdsPurchasingGetPurchasingVersion_mE6492691954CDAD86B5C50D6B1B02A7001AE311E();
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_PurchasingPlatform_UnityAdsPurchasingInitialize_mD17E792690AFEDD752DFB45CE5F24AA95D63B98B();


extern const Il2CppMethodPointer g_ReversePInvokeWrapperPointers[];
const Il2CppMethodPointer g_ReversePInvokeWrapperPointers[23] = 
{
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_OSSpecificSynchronizationContext_InvocationEntry_m0045E44F7E960D6B4A864D5206D4116249C09BB0),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosBanner_UnityAdsBannerDidShow_mDB64E458C30D007276D53173986276764C7B4591),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosBanner_UnityAdsBannerDidHide_m2D9B1C4E23A7C516C0C6AA3E3E78D6F4C8F8CB61),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosBanner_UnityAdsBannerClick_m9DDD7785E0ED0D952C973DB1F3C1A96B89D29660),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosBanner_UnityAdsBannerDidError_m4D2F6AB970DD9BDF7CCD5493D3E68A4F72C2AB69),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosBanner_UnityAdsBannerDidUnload_m21A59DD65BFEC00759582DE593B70B542A9C5D19),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosBanner_UnityAdsBannerDidLoad_m88E63E83A4731097E3AD6B23CE6C9D15C31DB855),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosInitializationListener_OnInitializationComplete_mCE07918F7BBF79FCA0F78C557453D91A747C63C9),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosInitializationListener_OnInitializationFailed_mD345F0A652BAF2869915CA3CB94D80CBBFF6E1B2),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosLoadListener_OnLoadSuccess_m8727A9C87753DA3ACEE846977DF048749DA79AA3),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosLoadListener_OnLoadFailure_mF25796FD82FC8C08F4F521E575A09A4AC7D36357),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosPlatform_UnityAdsReady_mE78B536B6B031C4337A32C4A352959D425C7CC37),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosPlatform_UnityAdsDidError_m2FBE6272AB73BFACFB07D2E316A5401969AD5B5D),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosPlatform_UnityAdsDidStart_m65935F1B8435546388E195950546F3AA5FA120B6),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosPlatform_UnityAdsDidFinish_m13B1C7444617B23A20E94AAC701F8130C1168A63),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosShowListener_OnShowFailure_mB7664BDA20F0A0094D82818A2572ADCAF8527FBB),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosShowListener_OnShowStart_m2BD70571938B2025172025054CD63E90192856FE),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosShowListener_OnShowClick_m38A42EC0E0FAA273339E46E2D9A4B8E9ADFAE5B9),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_IosShowListener_OnShowComplete_m28A5C41699323E6184CD0FEDC851010046C6056B),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_PurchasingPlatform_UnityAdsDidInitiatePurchasingCommand_m85ED160ECB9DBD1CC7D2731E0D090AFC451EDA81),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_PurchasingPlatform_UnityAdsPurchasingGetProductCatalog_mB34A1BA39F821C040DCF65C8099AA4E458DBEE48),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_PurchasingPlatform_UnityAdsPurchasingGetPurchasingVersion_mE6492691954CDAD86B5C50D6B1B02A7001AE311E),
	reinterpret_cast<Il2CppMethodPointer>(ReversePInvokeWrapper_PurchasingPlatform_UnityAdsPurchasingInitialize_mD17E792690AFEDD752DFB45CE5F24AA95D63B98B),
};
