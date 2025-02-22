﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

public class EdkDll
{
    public const Int32 EDK_OK                           = 0x0000;
    public const Int32 EDK_UNKNOWN_ERROR                = 0x0001;

    public const Int32 EDK_INVALID_PROFILE_ARCHIVE      = 0x0101;
    public const Int32 EDK_NO_USER_FOR_BASEPROFILE      = 0x0102;

    public const Int32 EDK_CANNOT_ACQUIRE_DATA          = 0x0200;

    public const Int32 EDK_BUFFER_TOO_SMALL             = 0x0300;
    public const Int32 EDK_OUT_OF_RANGE                 = 0x0301;
    public const Int32 EDK_INVALID_PARAMETER            = 0x0302;
    public const Int32 EDK_PARAMETER_LOCKED             = 0x0303;
    public const Int32 EDK_MC_INVALID_TRAINING_ACTION   = 0x0304;
    public const Int32 EDK_MC_INVALID_TRAINING_CONTROL  = 0x0305;
    public const Int32 EDK_MC_INVALID_ACTIVE_ACTION     = 0x0306;
    public const Int32 EDK_MC_EXCESS_MAX_ACTIONS        = 0x0307;
    public const Int32 EDK_FE_NO_SIG_AVAILABLE          = 0x0308;
    public const Int32 EDK_FILESYSTEM_ERROR             = 0x0309;

    public const Int32 EDK_INVALID_USER_ID              = 0x0400;

    public const Int32 EDK_EMOENGINE_UNINITIALIZED      = 0x0500;
    public const Int32 EDK_EMOENGINE_DISCONNECTED       = 0x0501;
    public const Int32 EDK_EMOENGINE_PROXY_ERROR        = 0x0502;

    public const Int32 EDK_NO_EVENT                     = 0x0600;

    public const Int32 EDK_GYRO_NOT_CALIBRATED          = 0x0700;

    public const Int32 EDK_OPTIMIZATION_IS_ON           = 0x0800;

    public const Int32 EDK_RESERVED1                    = 0x0900;

    public enum IEE_Event_t
    {
        IEE_UnknownEvent          = 0x0000,     //!< An unknown event.
        IEE_EmulatorError         = 0x0001,     //!< Error event from emulator. Connection to EmoComposer could be lost.
        IEE_ReservedEvent         = 0x0002,     //!< Reserved event.
        IEE_UserAdded             = 0x0010,     //!< A headset is connected.
        IEE_UserRemoved           = 0x0020,     //!< A headset has been disconnected.
        IEE_EmoStateUpdated       = 0x0040,     //!< Detection results have been updated from EmoEngine.
        IEE_ProfileEvent          = 0x0080,     //!< A profile has been returned from EmoEngine.
        IEE_MentalCommandEvent    = 0x0100,     //!< A IEE_MentalCommandEvent_t has been returned from EmoEngine.
        IEE_FacialExpressionEvent = 0x0200,     //!< A IEE_FacialExpressionEvent_t has been returned from EmoEngine.
        IEE_InternalStateChanged  = 0x0400,     //!< Reserved for internal use.
        IEE_AllEvent              = IEE_UserAdded | IEE_UserRemoved | IEE_EmoStateUpdated |
                                    IEE_ProfileEvent | IEE_MentalCommandEvent |
                                    IEE_FacialExpressionEvent | IEE_InternalStateChanged
                                                //!< Bit-mask for all events except error types
    };

    public enum IEE_FacialExpressionThreshold_t
    {
        FE_SENSITIVITY  //!< Sensitivity of each facial expression
    };
    public enum IEE_FacialExpressionTrainingControl_t
    {
        FE_NONE = 0,    //!< No action
        FE_START,       //!< Start a new training
        FE_ACCEPT,      //!< Accept current training
        FE_REJECT,      //!< Reject current training
        FE_ERASE,       //!< Erase training data for a facial expression
        FE_RESET        //!< Reset current training
    };

    public enum IEE_FacialExpressionSignature_t
    {
        FE_SIG_UNIVERSAL = 0,   //!< Use built-in universal signature
        FE_SIG_TRAINED          //!< Use custom trained signature
    };

    public enum IEE_MentalCommandTrainingControl_t
    {
        MC_NONE = 0,    //!< No action
        MC_START,       //!< Start a new training
        MC_ACCEPT,      //!< Accept current training
        MC_REJECT,      //!< Reject current training
        MC_ERASE,       //!< Erase training data for an action
        MC_RESET        //!< Reset current training
    };

    public enum IEE_FacialExpressionEvent_t
    {
        IEE_FacialExpressionNoEvent = 0,        //!< No new event
        IEE_FacialExpressionTrainingStarted,    //!< The training has begun after FE_START is sent.
        IEE_FacialExpressionTrainingSucceeded,  //!< The training is succeeded, waiting for FE_ACCEPT or FE_REJECT.
        IEE_FacialExpressionTrainingFailed,     //!< The training is failed due to signal issues. Please restart training.
        IEE_FacialExpressionTrainingCompleted,  //!< The training is completed after FE_ACCEPT is sent.
        IEE_FacialExpressionTrainingDataErased, //!< The training data for a particular facial expression has been erased by FE_ERASE.
        IEE_FacialExpressionTrainingRejected,   //!< The training is rejected after FE_REJECT is sent.
        IEE_FacialExpressionTrainingReset       //!< The training has been reset after FE_RESET is sent.
    };

    public enum IEE_MentalCommandEvent_t
    {
        IEE_MentalCommandNoEvent = 0,                   //!< No new event
        IEE_MentalCommandTrainingStarted,               //!< The training has begun after MC_START is sent.
        IEE_MentalCommandTrainingSucceeded,             //!< The training is succeeded, waiting for MC_ACCEPT or MC_REJECT.
        IEE_MentalCommandTrainingFailed,                //!< The training is failed due to signal issues. Please restart training.
        IEE_MentalCommandTrainingCompleted,             //!< The training is completed after MC_ACCEPT is sent.
        IEE_MentalCommandTrainingDataErased,            //!< The training data for a particular action has been erased by MC_ERASE.
        IEE_MentalCommandTrainingRejected,              //!< The training is rejected after MC_REJECT is sent.
        IEE_MentalCommandTrainingReset,                 //!< The training has been reset after MC_RESET is sent.
        IEE_MentalCommandAutoSamplingNeutralCompleted,  //!< The neutral training is completed.
        IEE_MentalCommandSignatureUpdated               //!< The mental command signature has been updated for new actions.
    };

    public enum IEE_EmotivSuite_t
    {
        IEE_FACIALEXPRESSION = 0,
        IEE_PERFORMANCEMETRIC,
        IEE_MENTALCOMMAND
    };

    public enum IEE_FacialExpressionAlgo_t
	{
		FE_NEUTRAL    = 0x0001,
		FE_BLINK      = 0x0002,
		FE_WINK_LEFT  = 0x0004,
		FE_WINK_RIGHT = 0x0008,
		FE_HORIEYE    = 0x0010,
		FE_SUPRISE    = 0x0020,
		FE_FROWN      = 0x0040,
		FE_SMILE      = 0x0080,
		FE_CLENCH     = 0x0100,

		FE_LAUGH      = 0x0200,
		FE_SMIRK_LEFT = 0x0400,
		FE_SMIRK_RIGHT = 0x0800
    } ;

	public enum IEE_MentalCommandAction_t
	{
		MC_NEUTRAL          = 0x0001,
		MC_PUSH             = 0x0002,
		MC_PULL             = 0x0004,
		MC_LIFT             = 0x0008,
		MC_DROP             = 0x0010,
        MC_LEFT             = 0x0020,
		MC_RIGHT            = 0x0040,
		MC_ROTATE_LEFT      = 0x0080,
		MC_ROTATE_RIGHT     = 0x0100,
		MC_ROTATE_CLOCKWISE = 0x0200,
		MC_ROTATE_COUNTER_CLOCKWISE = 0x0400,
		MC_ROTATE_FORWARDS  = 0x0800,
		MC_ROTATE_REVERSE   = 0x1000,
		MC_DISAPPEAR        = 0x2000
	} ;

    public enum IEE_MotionDataChannel_t
    {
        IMD_COUNTER = 0,        //!< Sample counter
        IMD_GYROX,              //!< Gyroscope X-axis
        IMD_GYROY,              //!< Gyroscope Y-axis
        IMD_GYROZ,              //!< Gyroscope Z-axis
        IMD_ACCX,               //!< Accelerometer X-axis
        IMD_ACCY,               //!< Accelerometer Y-axis
        IMD_ACCZ,               //!< Accelerometer Z-axis
        IMD_MAGX,               //!< Magnetometer X-axis
        IMD_MAGY,               //!< Magnetometer Y-axis
        IMD_MAGZ,               //!< Magnetometer Z-axis
        IMD_TIMESTAMP           //!< Timestamp of the motion data stream
    };

    [StructLayout(LayoutKind.Sequential)]
    public class IInputSensorDescriptor_t
    {
        public IEE_InputChannels_t channelId; // logical channel id
        public Int32 fExists;                 // does this sensor exist on this headset model
        public String pszLabel;               // text label identifying this sensor
        public Double xLoc;                   // x coordinate from center of head towards nose
        public Double yLoc;                   // y coordinate from center of head towards ears
        public Double zLoc;                   // z coordinate from center of head toward top of skull
    }

    public enum IEE_SignalStrength_t
    {
        NO_SIG = 0,
        BAD_SIG,
        GOOD_SIG
    };

    public enum IEE_InputChannels_t
    {
        IEE_CHAN_CMS = 0,
        IEE_CHAN_DRL,
        IEE_CHAN_FP1,
        IEE_CHAN_AF3,
        IEE_CHAN_F7,
        IEE_CHAN_F3,
        IEE_CHAN_FC5,
        IEE_CHAN_T7,
        IEE_CHAN_P7,
        //IEE_CHAN_Pz,
        IEE_CHAN_O1,            //IEE_CHAN_O1 = IEE_CHAN_Pz
        IEE_CHAN_O2,
        IEE_CHAN_P8,
        IEE_CHAN_T8,
        IEE_CHAN_FC6,
        IEE_CHAN_F4,
        IEE_CHAN_F8,
        IEE_CHAN_AF4,
        IEE_CHAN_FP2,
    };

    //! EEG and system data channel description
    public enum IEE_DataChannel_t
    {
        IED_COUNTER = 0,        //!< Sample counter
        IED_INTERPOLATED,       //!< Indicate if data is interpolated
        IED_RAW_CQ,             //!< Raw contact quality value
        IED_AF3,                //!< Channel AF3
        IED_F7,                 //!< Channel F7
        IED_F3,                 //!< Channel F3
        IED_FC5,                //!< Channel FC5
        IED_T7,                 //!< Channel T7
        IED_P7,                 //!< Channel P7
        IED_O1,                 //!< Channel O1 = Pz
        IED_O2,                 //!< Channel O2
        IED_P8,                 //!< Channel P8
        IED_T8,                 //!< Channel T8
        IED_FC6,                //!< Channel FC6
        IED_F4,                 //!< Channel F4
        IED_F8,                 //!< Channel F8
        IED_AF4,                //!< Channel AF4
        IED_GYROX,              //!< Gyroscope X-axis
        IED_GYROY,              //!< Gyroscope Y-axis
        IED_TIMESTAMP,          //!< System timestamp
        IED_MARKER_HARDWARE,    //!< Marker from extender
        IED_ES_TIMESTAMP,       //!< EmoState timestamp		
        IED_FUNC_ID,            //!< Reserved function id
        IED_FUNC_VALUE,         //!< Reserved function value
        IED_MARKER,             //!< Marker value from hardware
        IED_SYNC_SIGNAL         //!< Synchronisation signal
    };

    //! Windowing types enum for Fast Fourier Transform
    public enum IEE_WindowingTypes
    {
        IEE_HANNING   = 0,      //!< Hanning Window
        IEE_HAMMING   = 1,      //!< Hamming Window
        IEE_HANN      = 2,      //!< Hann Window
        IEE_BLACKMAN  = 3,      //!< Blackman-Harris Window
        IEE_RECTANGLE = 4       //!< Uniform/rectangular Window
    };

    public enum IEE_EEG_ContactQuality_t
    {
        IEEG_CQ_NO_SIGNAL,
        IEEG_CQ_VERY_BAD,
        IEEG_CQ_POOR,
        IEEG_CQ_FAIR,
        IEEG_CQ_GOOD
    };

#if UNITY_STANDALONE_WIN
    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineConnect")]
    static extern Int32 Unmanged_IEE_EngineConnect(String security);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineRemoteConnect")]
    static extern Int32 Unmanged_IEE_EngineRemoteConnect(String szHost, UInt16 port);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineDisconnect")]
    static extern Int32 Unmanged_IEE_EngineDisconnect();

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EnableDiagnostics")]
    static extern Int32 Unmanged_IEE_EnableDiagnostics(String szFilename, Int32 fEnable, Int32 nReserved);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoEngineEventCreate")]
    static extern IntPtr Unmanged_IEE_EmoEngineEventCreate();

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoEngineEventFree")]
    static extern void Unmanged_IEE_EmoEngineEventFree(IntPtr hEvent);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoStateCreate")]
    static extern IntPtr Unmanged_IEE_EmoStateCreate();

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoStateFree")]
    static extern void Unmanged_IEE_EmoStateFree(IntPtr hState);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoEngineEventGetType")]
    static extern IEE_Event_t Unmanged_IEE_EmoEngineEventGetType(IntPtr hEvent);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoEngineEventGetUserId")]
    static extern Int32 Unmanged_IEE_EmoEngineEventGetUserId(IntPtr hEvent, out UInt32 pUserIdOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoEngineEventGetEmoState")]
    static extern Int32 Unmanged_IEE_EmoEngineEventGetEmoState(IntPtr hEvent, IntPtr hEmoState);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineGetNextEvent")]
    static extern Int32 Unmanged_IEE_EngineGetNextEvent(IntPtr hEvent);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineClearEventQueue")]
    static extern Int32 Unmanged_IEE_EngineClearEventQueue(Int32 eventTypes);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineGetNumUser")]
    static extern Int32 Unmanged_IEE_EngineGetNumUser(out UInt32 pNumUserOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_SetHardwarePlayerDisplay")]
    static extern Int32 Unmanged_IEE_SetHardwarePlayerDisplay(UInt32 userId, UInt32 playerNum);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_HeadsetGetSensorDetails")]
    static extern Int32 Unmanged_IEE_HeadsetGetSensorDetails(IEE_InputChannels_t channelId, out IInputSensorDescriptor_t pDescriptorOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_HardwareGetVersion")]
    static extern Int32 Unmanged_IEE_HardwareGetVersion(UInt32 userId, out UInt32 pHwVersionOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_SoftwareGetVersion")]
    static extern Int32 Unmanged_IEE_SoftwareGetVersion(StringBuilder pszVersionOut, UInt32 nVersionChars, out UInt32 pBuildNumOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_HeadsetGetGyroDelta")]
    static extern Int32 Unmanged_IEE_HeadsetGetGyroDelta(UInt32 userId, out Int32 pXOut, out Int32 pYOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_HeadsetGyroRezero")]
    static extern Int32 Unmanged_IEE_HeadsetGyroRezero(UInt32 userId);

    //Set/Get headset setting for EPOC+ headset
    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_GetHeadsetSettings")]
    static extern Int32 Unmanaged_IEE_GetHeadsetSettings(UInt32 userId, out UInt32 EPOCmode, out UInt32 eegRate, out UInt32 eegRes, out UInt32 memsRate, out UInt32 memsRes);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_SetHeadsetSettings")]
    static extern Int32 Unmanaged_IEE_SetHeadsetSettings(UInt32 userId, UInt32 EPOCmode, UInt32 eegRate, UInt32 eegRes, UInt32 memsRate, UInt32 memsRes);

    //Motion Data
    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataCreate")]
    static extern IntPtr Unmanaged_IEE_MotionDataCreate();

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataFree")]
    static extern void Unmanaged_IEE_MotionDataFree(IntPtr hData);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataUpdateHandle")]
    static extern Int32 Unmanaged_IEE_MotionDataUpdateHandle(UInt32 userId, IntPtr hData);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataGet")]
    static extern Int32 Unmanaged_IEE_MotionDataGet(IntPtr hData, IEE_MotionDataChannel_t channel, Double[] buffer, UInt32 bufferSizeInSample);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataGetMultiChannels")]
    static extern Int32 Unmanaged_IEE_MotionDataGetMultiChannels(IntPtr hData, IEE_MotionDataChannel_t[] channelList, UInt32 nChannel, Double[][] buffer, UInt32 bufferSizeInSample);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataGetNumberOfSample")]
    static extern Int32 Unmanaged_IEE_MotionDataGetNumberOfSample(IntPtr hData, out UInt32 nSampleOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataSetBufferSizeInSec")]
    static extern Int32 Unmanaged_IEE_MotionDataSetBufferSizeInSec(Single bufferSizeInSec);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataGetBufferSizeInSec")]
    static extern Int32 Unmanaged_IEE_MotionDataGetBufferSizeInSec(out Single pBufferSizeInSecOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataGetSamplingRate")]
    static extern Int32 Unmanaged_IEE_MotionDataGetSamplingRate(UInt32 userId, out UInt32 pSamplingRate);


    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandEventGetType")]
    static extern IEE_MentalCommandEvent_t Unmanged_IEE_MentalCommandEventGetType(IntPtr hEvent);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionEventGetType")]
    static extern IEE_FacialExpressionEvent_t Unmanged_IEE_FacialExpressionEventGetType(IntPtr hEvent);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionSetThreshold")]
    static extern Int32 Unmanged_IEE_FacialExpressionSetThreshold(UInt32 userId, IEE_FacialExpressionAlgo_t algoName, IEE_FacialExpressionThreshold_t thresholdName, Int32 value);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetThreshold")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetThreshold(UInt32 userId, IEE_FacialExpressionAlgo_t algoName, IEE_FacialExpressionThreshold_t thresholdName, out Int32 pValueOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionSetTrainingAction")]
    static extern Int32 Unmanged_IEE_FacialExpressionSetTrainingAction(UInt32 userId, IEE_FacialExpressionAlgo_t action);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionSetTrainingControl")]
    static extern Int32 Unmanged_IEE_FacialExpressionSetTrainingControl(UInt32 userId, IEE_FacialExpressionTrainingControl_t control);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetTrainingAction")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetTrainingAction(UInt32 userId, out IEE_FacialExpressionAlgo_t pActionOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetTrainingTime")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetTrainingTime(UInt32 userId, out UInt32 pTrainingTimeOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetTrainedSignatureActions")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetTrainedSignatureActions(UInt32 userId, out UInt32 pTrainedActionsOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetTrainedSignatureAvailable")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetTrainedSignatureAvailable(UInt32 userId, out Int32 pfAvailableOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionSetSignatureType")]
    static extern Int32 Unmanged_IEE_FacialExpressionSetSignatureType(UInt32 userId, IEE_FacialExpressionSignature_t sigType);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetSignatureType")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetSignatureType(UInt32 userId, out IEE_FacialExpressionSignature_t pSigTypeOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetActiveActions")]
    static extern Int32 Unmanged_IEE_MentalCommandSetActiveActions(UInt32 userId, UInt32 activeActions);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetActiveActions")]
    static extern Int32 Unmanged_IEE_MentalCommandGetActiveActions(UInt32 userId, out UInt32 pActiveActionsOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetTrainingTime")]
    static extern Int32 Unmanged_IEE_MentalCommandGetTrainingTime(UInt32 userId, out UInt32 pTrainingTimeOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetTrainingControl")]
    static extern Int32 Unmanged_IEE_MentalCommandSetTrainingControl(UInt32 userId, IEE_MentalCommandTrainingControl_t control);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetTrainingAction")]
    static extern Int32 Unmanged_IEE_MentalCommandSetTrainingAction(UInt32 userId, IEE_MentalCommandAction_t action);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetTrainingAction")]
    static extern Int32 Unmanged_IEE_MentalCommandGetTrainingAction(UInt32 userId, out IEE_MentalCommandAction_t pActionOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetTrainedSignatureActions")]
    static extern Int32 Unmanged_IEE_MentalCommandGetTrainedSignatureActions(UInt32 userId, out UInt32 pTrainedActionsOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetOverallSkillRating")]
    static extern Int32 Unmanged_IEE_MentalCommandGetOverallSkillRating(UInt32 userId, out Single pOverallSkillRatingOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetActionSkillRating")]
    static extern Int32 Unmanged_IEE_MentalCommandGetActionSkillRating(UInt32 userId, IEE_MentalCommandAction_t action, out Single pActionSkillRatingOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetActivationLevel")]
    static extern Int32 Unmanged_IEE_MentalCommandSetActivationLevel(UInt32 userId, Int32 level);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetActionSensitivity")]
    static extern Int32 Unmanged_IEE_MentalCommandSetActionSensitivity(UInt32 userId,
                                        Int32 action1Sensitivity, Int32 action2Sensitivity,
                                        Int32 action3Sensitivity, Int32 action4Sensitivity);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetActivationLevel")]
    static extern Int32 Unmanged_IEE_MentalCommandGetActivationLevel(UInt32 userId, out Int32 pLevelOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetActionSensitivity")]
    static extern Int32 Unmanged_IEE_MentalCommandGetActionSensitivity(UInt32 userId,
                                        out Int32 pAction1SensitivityOut, out Int32 pAction2SensitivityOut,
                                        out Int32 pAction3SensitivityOut, out Int32 pAction4SensitivityOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandStartSamplingNeutral")]
    static extern Int32 Unmanged_IEE_MentalCommandStartSamplingNeutral(UInt32 userId);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandStopSamplingNeutral")]
    static extern Int32 Unmanged_IEE_MentalCommandStopSamplingNeutral(UInt32 userId);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetSignatureCaching")]
    static extern Int32 Unmanged_IEE_MentalCommandSetSignatureCaching(UInt32 userId, UInt32 enabled);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetSignatureCaching")]
    static extern Int32 Unmanged_IEE_MentalCommandGetSignatureCaching(UInt32 userId, out UInt32 pEnabledOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetSignatureCacheSize")]
    static extern Int32 Unmanged_IEE_MentalCommandSetSignatureCacheSize(UInt32 userId, UInt32 size);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetSignatureCacheSize")]
    static extern Int32 Unmanged_IEE_MentalCommandGetSignatureCacheSize(UInt32 userId, out UInt32 pSizeOut);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_GetAverageBandPowers")]
    static extern Int32 Unmanged_IEE_GetAverageBandPowers(UInt32 userId, IEE_DataChannel_t channel, Double[] theta, Double[] alpha, Double[] low_beta, Double[] high_beta, Double[] gamma);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FFTSetWindowingType")]
    static extern Int32 Unmanged_IEE_FFTSetWindowingType(UInt32 userId, IEE_WindowingTypes type);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FFTGetWindowingType")]
    static extern Int32 Unmanged_IEE_FFTGetWindowingType(UInt32 userId, out IEE_WindowingTypes type);


    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsBlink")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsBlink(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsLeftWink")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsLeftWink(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsRightWink")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsRightWink(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsEyesOpen")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsEyesOpen(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsLookingUp")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsLookingUp(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsLookingDown")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsLookingDown(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsLookingLeft")]
    static extern Int32 Unmanaged_IS_FacialExpressionIsLookingLeft(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsLookingRight")]
    static extern Int32 Unmanaged_IS_FacialExpressionIsLookingRight(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetEyelidState")]
    static extern void Unmanaged_IS_FacialExpressionGetEyelidState(IntPtr state, out Single leftEye, out Single rightEye);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetEyeLocation")]
    static extern void Unmanaged_IS_FacialExpressionGetEyeLocation(IntPtr state, out Single x, out Single y);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetEyebrowExtent")]
    static extern Single Unmanaged_IS_FacialExpressionGetEyebrowExtent(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetSmileExtent")]
    static extern Single Unmanaged_IS_FacialExpressionGetSmileExtent(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetClenchExtent")]
    static extern Single Unmanaged_IS_FacialExpressionGetClenchExtent(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetUpperFaceAction")]
    static extern IEE_FacialExpressionAlgo_t Unmanaged_IS_FacialExpressionGetUpperFaceAction(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetUpperFaceActionPower")]
    static extern Single Unmanaged_IS_FacialExpressionGetUpperFaceActionPower(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetLowerFaceAction")]
    static extern IEE_FacialExpressionAlgo_t Unmanaged_IS_FacialExpressionGetLowerFaceAction(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetLowerFaceActionPower")]
    static extern Single Unmanaged_IS_FacialExpressionGetLowerFaceActionPower(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsActive")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsActive(IntPtr state, IEE_FacialExpressionAlgo_t type);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_MentalCommandGetCurrentAction")]
    static extern IEE_MentalCommandAction_t Unmanaged_IS_MentalCommandGetCurrentAction(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_MentalCommandGetCurrentActionPower")]
    static extern Single Unmanaged_IS_MentalCommandGetCurrentActionPower(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_MentalCommandIsActive")]
    static extern Boolean Unmanaged_IS_MentalCommandIsActive(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionEqual")]
    static extern Boolean Unmanaged_IS_FacialExpressionEqual(IntPtr a, IntPtr b);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_MentalCommandEqual")]
    static extern Boolean Unmanaged_IS_MentalCommandEqual(IntPtr a, IntPtr b);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_Create")]
    static extern IntPtr Unmanaged_IS_Create();

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_Free")]
    static extern void Unmanaged_IS_Free(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_Init")]
    static extern void Unmanaged_IS_Init(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetTimeFromStart")]
    static extern Single Unmanaged_IS_GetTimeFromStart(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetHeadsetOn")]
    static extern Int32 Unmanaged_IS_GetHeadsetOn(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetNumContactQualityChannels")]
    static extern Int32 Unmanaged_IS_GetNumContactQualityChannels(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetContactQuality")]
    static extern IEE_EEG_ContactQuality_t Unmanaged_IS_GetContactQuality(IntPtr state, Int32 electroIdx);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetContactQualityFromAllChannels")]
    static extern Int32 Unmanaged_IS_GetContactQualityFromAllChannels(IntPtr state, IEE_EEG_ContactQuality_t[] contactQuality, UInt32 numChannels);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetWirelessSignalStatus")]
    static extern IEE_SignalStrength_t Unmanaged_IS_GetWirelessSignalStatus(IntPtr state);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_Copy")]
    static extern void Unmanaged_IS_Copy(IntPtr a, IntPtr b);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_EmoEngineEqual")]
    static extern Boolean Unmanaged_IS_EmoEngineEqual(IntPtr a, IntPtr b);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_Equal")]
    static extern Boolean Unmanaged_IS_Equal(IntPtr a, IntPtr b);

    [DllImport("edk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetBatteryChargeLevel")]
    static extern void Unmanaged_IS_GetBatteryChargeLevel(IntPtr state, out Int32 chargeLevel, out Int32 maxChargeLevel);

#endif

#if (UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_ANDROID)

	#if UNITY_STANDALONE_OSX
		[DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_GetInsightDeviceName")]
		static extern string IEE_GetInsightDeviceName(int index);

		[DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_GetEpocPlusDeviceName")]
		static extern string IEE_GetEpocPlusDeviceName(int index);
	
		[DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_GetInsightDeviceState")]
		static extern string IEE_GetInsightDeviceState(out Int32 state, int index);

		[DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_GetEpocPlusDeviceState")]
		static extern string IEE_GetEpocPlusDeviceState(out Int32 state, int index);

		[DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_GetEpocPlusDeviceCount")]
		static extern Int32 IEE_GetEpocPlusDeviceCount();
	
		[DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_ConnectEpocPlusDevice")]
		static extern Int32 IEE_ConnectEpocPlusDevice(int index);

		[DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_GetInsightDeviceCount")]
		static extern Int32 IEE_GetInsightDeviceCount();
	
		[DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_ConnectInsightDevice")]
		static extern Int32 IEE_ConnectInsightDevice(int index);
	
		[DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoConnectDevice")]
		static extern Int32 IEE_EmoConnectDevice(int index);
	
		[DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoInitDevice")]
		static extern Boolean IEE_EmoInitDevice();

	#endif
    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineConnect")]
    static extern Int32 Unmanged_IEE_EngineConnect(String security);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineRemoteConnect")]
    static extern Int32 Unmanged_IEE_EngineRemoteConnect(String szHost, UInt16 port);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineDisconnect")]
    static extern Int32 Unmanged_IEE_EngineDisconnect();

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EnableDiagnostics")]
    static extern Int32 Unmanged_IEE_EnableDiagnostics(String szFilename, Int32 fEnable, Int32 nReserved);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoEngineEventCreate")]
    static extern IntPtr Unmanged_IEE_EmoEngineEventCreate();

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoEngineEventFree")]
    static extern void Unmanged_IEE_EmoEngineEventFree(IntPtr hEvent);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoStateCreate")]
    static extern IntPtr Unmanged_IEE_EmoStateCreate();

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoStateFree")]
    static extern void Unmanged_IEE_EmoStateFree(IntPtr hState);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoEngineEventGetType")]
    static extern IEE_Event_t Unmanged_IEE_EmoEngineEventGetType(IntPtr hEvent);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoEngineEventGetUserId")]
    static extern Int32 Unmanged_IEE_EmoEngineEventGetUserId(IntPtr hEvent, out UInt32 pUserIdOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EmoEngineEventGetEmoState")]
    static extern Int32 Unmanged_IEE_EmoEngineEventGetEmoState(IntPtr hEvent, IntPtr hEmoState);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineGetNextEvent")]
    static extern Int32 Unmanged_IEE_EngineGetNextEvent(IntPtr hEvent);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineClearEventQueue")]
    static extern Int32 Unmanged_IEE_EngineClearEventQueue(Int32 eventTypes);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_EngineGetNumUser")]
    static extern Int32 Unmanged_IEE_EngineGetNumUser(out UInt32 pNumUserOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_SetHardwarePlayerDisplay")]
    static extern Int32 Unmanged_IEE_SetHardwarePlayerDisplay(UInt32 userId, UInt32 playerNum);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_HeadsetGetSensorDetails")]
    static extern Int32 Unmanged_IEE_HeadsetGetSensorDetails(IEE_InputChannels_t channelId, out IInputSensorDescriptor_t pDescriptorOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_HardwareGetVersion")]
    static extern Int32 Unmanged_IEE_HardwareGetVersion(UInt32 userId, out UInt32 pHwVersionOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_SoftwareGetVersion")]
    static extern Int32 Unmanged_IEE_SoftwareGetVersion(StringBuilder pszVersionOut, UInt32 nVersionChars, out UInt32 pBuildNumOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_HeadsetGetGyroDelta")]
    static extern Int32 Unmanged_IEE_HeadsetGetGyroDelta(UInt32 userId, out Int32 pXOut, out Int32 pYOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_HeadsetGyroRezero")]
    static extern Int32 Unmanged_IEE_HeadsetGyroRezero(UInt32 userId);

    //Set/Get headset setting for EPOC+ headset
    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_GetHeadsetSettings")]
    static extern Int32 Unmanaged_IEE_GetHeadsetSettings(UInt32 userId, out UInt32 EPOCmode, out UInt32 eegRate, out UInt32 eegRes, out UInt32 memsRate, out UInt32 memsRes);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_SetHeadsetSettings")]
    static extern Int32 Unmanaged_IEE_SetHeadsetSettings(UInt32 userId, UInt32 EPOCmode, UInt32 eegRate, UInt32 eegRes, UInt32 memsRate, UInt32 memsRes);

    //Motion Data
    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataCreate")]
    static extern IntPtr Unmanaged_IEE_MotionDataCreate();

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataFree")]
    static extern void Unmanaged_IEE_MotionDataFree(IntPtr hData);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataUpdateHandle")]
    static extern Int32 Unmanaged_IEE_MotionDataUpdateHandle(UInt32 userId, IntPtr hData);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataGet")]
    static extern Int32 Unmanaged_IEE_MotionDataGet(IntPtr hData, IEE_MotionDataChannel_t channel, Double[] buffer, UInt32 bufferSizeInSample);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataGetMultiChannels")]
    static extern Int32 Unmanaged_IEE_MotionDataGetMultiChannels(IntPtr hData, IEE_MotionDataChannel_t[] channelList, UInt32 nChannel, Double[][] buffer, UInt32 bufferSizeInSample);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataGetNumberOfSample")]
    static extern Int32 Unmanaged_IEE_MotionDataGetNumberOfSample(IntPtr hData, out UInt32 nSampleOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataSetBufferSizeInSec")]
    static extern Int32 Unmanaged_IEE_MotionDataSetBufferSizeInSec(Single bufferSizeInSec);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataGetBufferSizeInSec")]
    static extern Int32 Unmanaged_IEE_MotionDataGetBufferSizeInSec(out Single pBufferSizeInSecOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MotionDataGetSamplingRate")]
    static extern Int32 Unmanaged_IEE_MotionDataGetSamplingRate(UInt32 userId, out UInt32 pSamplingRate);


    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandEventGetType")]
    static extern IEE_MentalCommandEvent_t Unmanged_IEE_MentalCommandEventGetType(IntPtr hEvent);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionEventGetType")]
    static extern IEE_FacialExpressionEvent_t Unmanged_IEE_FacialExpressionEventGetType(IntPtr hEvent);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionSetThreshold")]
    static extern Int32 Unmanged_IEE_FacialExpressionSetThreshold(UInt32 userId, IEE_FacialExpressionAlgo_t algoName, IEE_FacialExpressionThreshold_t thresholdName, Int32 value);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetThreshold")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetThreshold(UInt32 userId, IEE_FacialExpressionAlgo_t algoName, IEE_FacialExpressionThreshold_t thresholdName, out Int32 pValueOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionSetTrainingAction")]
    static extern Int32 Unmanged_IEE_FacialExpressionSetTrainingAction(UInt32 userId, IEE_FacialExpressionAlgo_t action);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionSetTrainingControl")]
    static extern Int32 Unmanged_IEE_FacialExpressionSetTrainingControl(UInt32 userId, IEE_FacialExpressionTrainingControl_t control);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetTrainingAction")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetTrainingAction(UInt32 userId, out IEE_FacialExpressionAlgo_t pActionOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetTrainingTime")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetTrainingTime(UInt32 userId, out UInt32 pTrainingTimeOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetTrainedSignatureActions")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetTrainedSignatureActions(UInt32 userId, out UInt32 pTrainedActionsOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetTrainedSignatureAvailable")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetTrainedSignatureAvailable(UInt32 userId, out Int32 pfAvailableOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionSetSignatureType")]
    static extern Int32 Unmanged_IEE_FacialExpressionSetSignatureType(UInt32 userId, IEE_FacialExpressionSignature_t sigType);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FacialExpressionGetSignatureType")]
    static extern Int32 Unmanged_IEE_FacialExpressionGetSignatureType(UInt32 userId, out IEE_FacialExpressionSignature_t pSigTypeOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetActiveActions")]
    static extern Int32 Unmanged_IEE_MentalCommandSetActiveActions(UInt32 userId, UInt32 activeActions);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetActiveActions")]
    static extern Int32 Unmanged_IEE_MentalCommandGetActiveActions(UInt32 userId, out UInt32 pActiveActionsOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetTrainingTime")]
    static extern Int32 Unmanged_IEE_MentalCommandGetTrainingTime(UInt32 userId, out UInt32 pTrainingTimeOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetTrainingControl")]
    static extern Int32 Unmanged_IEE_MentalCommandSetTrainingControl(UInt32 userId, IEE_MentalCommandTrainingControl_t control);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetTrainingAction")]
    static extern Int32 Unmanged_IEE_MentalCommandSetTrainingAction(UInt32 userId, IEE_MentalCommandAction_t action);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetTrainingAction")]
    static extern Int32 Unmanged_IEE_MentalCommandGetTrainingAction(UInt32 userId, out IEE_MentalCommandAction_t pActionOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetTrainedSignatureActions")]
    static extern Int32 Unmanged_IEE_MentalCommandGetTrainedSignatureActions(UInt32 userId, out UInt32 pTrainedActionsOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetOverallSkillRating")]
    static extern Int32 Unmanged_IEE_MentalCommandGetOverallSkillRating(UInt32 userId, out Single pOverallSkillRatingOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetActionSkillRating")]
    static extern Int32 Unmanged_IEE_MentalCommandGetActionSkillRating(UInt32 userId, IEE_MentalCommandAction_t action, out Single pActionSkillRatingOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetActivationLevel")]
    static extern Int32 Unmanged_IEE_MentalCommandSetActivationLevel(UInt32 userId, Int32 level);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetActionSensitivity")]
    static extern Int32 Unmanged_IEE_MentalCommandSetActionSensitivity(UInt32 userId,
                                        Int32 action1Sensitivity, Int32 action2Sensitivity,
                                        Int32 action3Sensitivity, Int32 action4Sensitivity);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetActivationLevel")]
    static extern Int32 Unmanged_IEE_MentalCommandGetActivationLevel(UInt32 userId, out Int32 pLevelOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetActionSensitivity")]
    static extern Int32 Unmanged_IEE_MentalCommandGetActionSensitivity(UInt32 userId,
                                        out Int32 pAction1SensitivityOut, out Int32 pAction2SensitivityOut,
                                        out Int32 pAction3SensitivityOut, out Int32 pAction4SensitivityOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandStartSamplingNeutral")]
    static extern Int32 Unmanged_IEE_MentalCommandStartSamplingNeutral(UInt32 userId);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandStopSamplingNeutral")]
    static extern Int32 Unmanged_IEE_MentalCommandStopSamplingNeutral(UInt32 userId);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetSignatureCaching")]
    static extern Int32 Unmanged_IEE_MentalCommandSetSignatureCaching(UInt32 userId, UInt32 enabled);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetSignatureCaching")]
    static extern Int32 Unmanged_IEE_MentalCommandGetSignatureCaching(UInt32 userId, out UInt32 pEnabledOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandSetSignatureCacheSize")]
    static extern Int32 Unmanged_IEE_MentalCommandSetSignatureCacheSize(UInt32 userId, UInt32 size);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_MentalCommandGetSignatureCacheSize")]
    static extern Int32 Unmanged_IEE_MentalCommandGetSignatureCacheSize(UInt32 userId, out UInt32 pSizeOut);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_GetAverageBandPowers")]
    static extern Int32 Unmanged_IEE_GetAverageBandPowers(UInt32 userId, IEE_DataChannel_t channel, Double[] theta, Double[] alpha, Double[] low_beta, Double[] high_beta, Double[] gamma);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FFTSetWindowingType")]
    static extern Int32 Unmanged_IEE_FFTSetWindowingType(UInt32 userId, IEE_WindowingTypes type);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IEE_FFTGetWindowingType")]
    static extern Int32 Unmanged_IEE_FFTGetWindowingType(UInt32 userId, out IEE_WindowingTypes type);


    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsBlink")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsBlink(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsLeftWink")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsLeftWink(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsRightWink")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsRightWink(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsEyesOpen")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsEyesOpen(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsLookingUp")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsLookingUp(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsLookingDown")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsLookingDown(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsLookingLeft")]
    static extern Int32 Unmanaged_IS_FacialExpressionIsLookingLeft(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsLookingRight")]
    static extern Int32 Unmanaged_IS_FacialExpressionIsLookingRight(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetEyelidState")]
    static extern void Unmanaged_IS_FacialExpressionGetEyelidState(IntPtr state, out Single leftEye, out Single rightEye);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetEyeLocation")]
    static extern void Unmanaged_IS_FacialExpressionGetEyeLocation(IntPtr state, out Single x, out Single y);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetEyebrowExtent")]
    static extern Single Unmanaged_IS_FacialExpressionGetEyebrowExtent(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetSmileExtent")]
    static extern Single Unmanaged_IS_FacialExpressionGetSmileExtent(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetClenchExtent")]
    static extern Single Unmanaged_IS_FacialExpressionGetClenchExtent(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetUpperFaceAction")]
    static extern IEE_FacialExpressionAlgo_t Unmanaged_IS_FacialExpressionGetUpperFaceAction(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetUpperFaceActionPower")]
    static extern Single Unmanaged_IS_FacialExpressionGetUpperFaceActionPower(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetLowerFaceAction")]
    static extern IEE_FacialExpressionAlgo_t Unmanaged_IS_FacialExpressionGetLowerFaceAction(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionGetLowerFaceActionPower")]
    static extern Single Unmanaged_IS_FacialExpressionGetLowerFaceActionPower(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionIsActive")]
    static extern Boolean Unmanaged_IS_FacialExpressionIsActive(IntPtr state, IEE_FacialExpressionAlgo_t type);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_MentalCommandGetCurrentAction")]
    static extern IEE_MentalCommandAction_t Unmanaged_IS_MentalCommandGetCurrentAction(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_MentalCommandGetCurrentActionPower")]
    static extern Single Unmanaged_IS_MentalCommandGetCurrentActionPower(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_MentalCommandIsActive")]
    static extern Boolean Unmanaged_IS_MentalCommandIsActive(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_FacialExpressionEqual")]
    static extern Boolean Unmanaged_IS_FacialExpressionEqual(IntPtr a, IntPtr b);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_MentalCommandEqual")]
    static extern Boolean Unmanaged_IS_MentalCommandEqual(IntPtr a, IntPtr b);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_Create")]
    static extern IntPtr Unmanaged_IS_Create();

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_Free")]
    static extern void Unmanaged_IS_Free(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_Init")]
    static extern void Unmanaged_IS_Init(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetTimeFromStart")]
    static extern Single Unmanaged_IS_GetTimeFromStart(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetHeadsetOn")]
    static extern Int32 Unmanaged_IS_GetHeadsetOn(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetNumContactQualityChannels")]
    static extern Int32 Unmanaged_IS_GetNumContactQualityChannels(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetContactQuality")]
    static extern IEE_EEG_ContactQuality_t Unmanaged_IS_GetContactQuality(IntPtr state, Int32 electroIdx);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetContactQualityFromAllChannels")]
    static extern Int32 Unmanaged_IS_GetContactQualityFromAllChannels(IntPtr state, IEE_EEG_ContactQuality_t[] contactQuality, UInt32 numChannels);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetWirelessSignalStatus")]
    static extern IEE_SignalStrength_t Unmanaged_IS_GetWirelessSignalStatus(IntPtr state);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_Copy")]
    static extern void Unmanaged_IS_Copy(IntPtr a, IntPtr b);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_EmoEngineEqual")]
    static extern Boolean Unmanaged_IS_EmoEngineEqual(IntPtr a, IntPtr b);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_Equal")]
    static extern Boolean Unmanaged_IS_Equal(IntPtr a, IntPtr b);

    [DllImport("edk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IS_GetBatteryChargeLevel")]
    static extern void Unmanaged_IS_GetBatteryChargeLevel(IntPtr state, out Int32 chargeLevel, out Int32 maxChargeLevel);

#endif

#if (UNITY_IPHONE || UNITY_IOS)
	[DllImport("__Internal")]
	public static extern Int32 IEE_EngineConnect(String securityCode);

	[DllImport("__Internal")]
	public static extern Int32 IEE_EngineRemoteConnect(String szHost, UInt16 port);

	[DllImport("__Internal")]
	public static extern Int32 IEE_EngineDisconnect();

	[DllImport("__Internal")]
	public static extern Int32 IEE_EnableDiagnostics(String szFilename, Int32 fEnable, Int32 nReserved);

	[DllImport("__Internal")]
	public static extern IntPtr IEE_EmoEngineEventCreate();

	[DllImport("__Internal")]
	public static extern void IEE_EmoEngineEventFree(IntPtr hEvent);

	[DllImport("__Internal")]
	public static extern IntPtr IEE_EmoStateCreate();

	[DllImport("__Internal")]
	public static extern void IEE_EmoStateFree(IntPtr hState);

	[DllImport("__Internal")]
	public static extern IEE_Event_t IEE_EmoEngineEventGetType(IntPtr hEvent);

	[DllImport("__Internal")]
	public static extern IEE_MentalCommandEvent_t IEE_MentalCommandEventGetType(IntPtr hEvent);

	[DllImport("__Internal")]
	public static extern IEE_FacialExpressionEvent_t IEE_FacialExpressionEventGetType(IntPtr hEvent);

	[DllImport("__Internal")]
	public static extern Int32 IEE_EmoEngineEventGetUserId(IntPtr hEvent, out UInt32 pUserIdOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_EmoEngineEventGetEmoState(IntPtr hEvent, IntPtr hEmoState);

	[DllImport("__Internal")]
	public static extern Int32 IEE_EngineGetNextEvent(IntPtr hEvent);

	[DllImport("__Internal")]
	public static extern Int32 IEE_EngineClearEventQueue(Int32 eventTypes);

	[DllImport("__Internal")]
	public static extern Int32 IEE_EngineGetNumUser(out UInt32 pNumUserOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_SetHardwarePlayerDisplay(UInt32 userId, UInt32 playerNum);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FacialExpressionSetThreshold(UInt32 userId, IEE_FacialExpressionAlgo_t algoName, IEE_FacialExpressionThreshold_t thresholdName, Int32 value);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FacialExpressionGetThreshold(UInt32 userId, IEE_FacialExpressionAlgo_t algoName, IEE_FacialExpressionThreshold_t thresholdName, out Int32 pValueOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FacialExpressionSetTrainingAction(UInt32 userId, IEE_FacialExpressionAlgo_t action);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FacialExpressionSetTrainingControl(UInt32 userId, IEE_FacialExpressionTrainingControl_t control);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FacialExpressionGetTrainingAction(UInt32 userId, out IEE_FacialExpressionAlgo_t pActionOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FacialExpressionGetTrainingTime(UInt32 userId, out UInt32 pTrainingTimeOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FacialExpressionGetTrainedSignatureActions(UInt32 userId, out UInt32 pTrainedActionsOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FacialExpressionGetTrainedSignatureAvailable(UInt32 userId, out Int32 pfAvailableOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FacialExpressionSetSignatureType(UInt32 userId, IEE_FacialExpressionSignature_t sigType);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FacialExpressionGetSignatureType(UInt32 userId, out IEE_FacialExpressionSignature_t pSigTypeOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandSetActiveActions(UInt32 userId, UInt32 activeActions);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandGetActiveActions(UInt32 userId, out UInt32 pActiveActionsOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandGetTrainingTime(UInt32 userId, out UInt32 pTrainingTimeOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandSetTrainingControl(UInt32 userId, IEE_MentalCommandTrainingControl_t control);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandSetTrainingAction(UInt32 userId, IEE_MentalCommandAction_t action);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandGetTrainingAction(UInt32 userId, out IEE_MentalCommandAction_t pActionOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandGetTrainedSignatureActions(UInt32 userId, out UInt32 pTrainedActionsOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandGetOverallSkillRating(UInt32 userId, out Single pOverallSkillRatingOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandGetActionSkillRating(UInt32 userId, IEE_MentalCommandAction_t action, out Single pActionSkillRatingOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandSetActivationLevel(UInt32 userId, Int32 level);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandSetActionSensitivity(UInt32 userId,

	Int32 action1Sensitivity, Int32 action2Sensitivity,
	Int32 action3Sensitivity, Int32 action4Sensitivity);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandGetActivationLevel(UInt32 userId, out Int32 pLevelOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandGetActionSensitivity(UInt32 userId,
	out Int32 pAction1SensitivityOut, out Int32 pAction2SensitivityOut,
	out Int32 pAction3SensitivityOut, out Int32 pAction4SensitivityOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandStartSamplingNeutral(UInt32 userId);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandStopSamplingNeutral(UInt32 userId);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandSetSignatureCaching(UInt32 userId, UInt32 enabled);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandGetSignatureCaching(UInt32 userId, out UInt32 pEnabledOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandSetSignatureCacheSize(UInt32 userId, UInt32 size);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MentalCommandGetSignatureCacheSize(UInt32 userId, out UInt32 pSizeOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_HeadsetGetSensorDetails(IEE_InputChannels_t channelId, out IInputSensorDescriptor_t pDescriptorOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_HardwareGetVersion(UInt32 userId, out UInt32 pHwVersionOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_SoftwareGetVersion(StringBuilder pszVersionOut, UInt32 nVersionChars, out UInt32 pBuildNumOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_HeadsetGetGyroDelta(UInt32 userId, out Int32 pXOut, out Int32 pYOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_HeadsetGyroRezero(UInt32 userId);

	[DllImport("__Internal")]
	public static extern IntPtr IS_Create();

	[DllImport("__Internal")]
	public static extern void IS_Free(IntPtr state);

	[DllImport("__Internal")]
	public static extern void IS_Init(IntPtr state);

	[DllImport("__Internal")]
	public static extern Single IS_GetTimeFromStart(IntPtr state);

	[DllImport("__Internal")]
	public static extern Int32 IS_GetHeadsetOn(IntPtr state);

	[DllImport("__Internal")]
	public static extern Int32 IS_GetNumContactQualityChannels(IntPtr state);

	[DllImport("__Internal")]
	public static extern IEE_EEG_ContactQuality_t IS_GetContactQuality(IntPtr state, Int32 electroIdx);

	[DllImport("__Internal")]
	private static extern Int32 IS_GetContactQualityFromAllChannels(IntPtr state, IEE_EEG_ContactQuality_t[] contactQuality, UInt32 numChannels);

	public static Int32 IS_GetContactQualityFromAllChannels(IntPtr state, out IEE_EEG_ContactQuality_t[] contactQuality)
	{
		Int32 numChannels = EdkDll.IS_GetNumContactQualityChannels(state);
		contactQuality    = new IEE_EEG_ContactQuality_t[numChannels];
		return IS_GetContactQualityFromAllChannels(state, contactQuality, (UInt32)contactQuality.Length);
	}

	[DllImport("__Internal")]
	public static extern Boolean IS_FacialExpressionIsBlink(IntPtr state);

	[DllImport("__Internal")]
	public static extern Boolean IS_FacialExpressionIsLeftWink(IntPtr state);

	[DllImport("__Internal")]
	public static extern Boolean IS_FacialExpressionIsRightWink(IntPtr state);

	[DllImport("__Internal")]
	public static extern Boolean IS_FacialExpressionIsEyesOpen(IntPtr state);

	[DllImport("__Internal")]
	public static extern Boolean IS_FacialExpressionIsLookingUp(IntPtr state);

	[DllImport("__Internal")]
	public static extern Boolean IS_FacialExpressionIsLookingDown(IntPtr state);

	[DllImport("__Internal")]
	public static extern void IS_FacialExpressionGetEyelidState(IntPtr state, out Single leftEye, out Single rightEye);

	[DllImport("__Internal")]
	public static extern void IS_FacialExpressionGetEyeLocation(IntPtr state, out Single x, out Single y);

	[DllImport("__Internal")]
	public static extern Single IS_FacialExpressionGetEyebrowExtent(IntPtr state);

	[DllImport("__Internal")]
	public static extern Single IS_FacialExpressionGetSmileExtent(IntPtr state);

	[DllImport("__Internal")]
	public static extern Single IS_FacialExpressionGetClenchExtent(IntPtr state);

	[DllImport("__Internal")]
	public static extern IEE_FacialExpressionAlgo_t IS_FacialExpressionGetUpperFaceAction(IntPtr state);

	[DllImport("__Internal")]
	public static extern Single IS_FacialExpressionGetUpperFaceActionPower(IntPtr state);

	[DllImport("__Internal")]
	public static extern IEE_FacialExpressionAlgo_t IS_FacialExpressionGetLowerFaceAction(IntPtr state);

	[DllImport("__Internal")]
	public static extern Single IS_FacialExpressionGetLowerFaceActionPower(IntPtr state);

	[DllImport("__Internal")]
	public static extern Boolean IS_FacialExpressionIsActive(IntPtr state, IEE_FacialExpressionAlgo_t type);

	[DllImport("__Internal")]
	public static extern IEE_MentalCommandAction_t IS_MentalCommandGetCurrentAction(IntPtr state);

	[DllImport("__Internal")]
	public static extern Single IS_MentalCommandGetCurrentActionPower(IntPtr state);

	[DllImport("__Internal")]
	public static extern Boolean IS_MentalCommandIsActive(IntPtr state);

	[DllImport("__Internal")]
	public static extern IEE_SignalStrength_t IS_GetWirelessSignalStatus(IntPtr state);

	[DllImport("__Internal")]
	public static extern void IS_Copy(IntPtr a, IntPtr b);

	[DllImport("__Internal")]
	public static extern Boolean IS_FacialExpressionEqual(IntPtr a, IntPtr b);

	[DllImport("__Internal")]
	public static extern Boolean IS_MentalCommandEqual(IntPtr a, IntPtr b);

	[DllImport("__Internal")]
	public static extern Boolean IS_EmoEngineEqual(IntPtr a, IntPtr b);

	[DllImport("__Internal")]
	public static extern Boolean IS_Equal(IntPtr a, IntPtr b);

	[DllImport("__Internal")]
	public static extern void IS_GetBatteryChargeLevel(IntPtr state, out Int32 chargeLevel, out Int32 maxChargeLevel);

	[DllImport ("__Internal")]
	public static extern Boolean IEE_EmoInitDevice();
	
	[DllImport("__Internal")]
	public static extern Int32 IEE_GetInsightDeviceCount();

	[DllImport("__Internal")]
	public static extern string IEE_GetInsightDeviceName(int index);

	[DllImport("__Internal")]
	public static extern void IEE_GetInsightDeviceState(out Int32 state, int index);

	[DllImport("__Internal")]
	public static extern Int32 IEE_ConnectEpocPlusDevice(Int32 index);

	[DllImport("__Internal")]
	public static extern Int32 IEE_GetEpocPlusDeviceCount();

	[DllImport("__Internal")]
	public static extern string IEE_GetEpocPlusDeviceName(int index);

	[DllImport("__Internal")]
	public static extern void IEE_GetEpocPlusDeviceState(out Int32 state, int index);

	[DllImport("__Internal")]
	public static extern Int32 IEE_ConnectInsightDevice(Int32 index);

	[DllImport("__Internal")]
	public static extern IntPtr IEE_MotionDataCreate();

	[DllImport("__Internal")]
	public static extern void IEE_MotionDataFree(IntPtr hMotion);

	[DllImport("__Internal")]
	public static extern Int32 IEE_GetHeadsetSettings(UInt32 userId, out UInt32 EPOCmode, out UInt32 eegRate, out UInt32 eegRes, out UInt32 memsRate, out UInt32 memsRes);

	[DllImport("__Internal")]
	public static extern Int32 IEE_SetHeadsetSettings(UInt32 userId, UInt32 EPOCmode, UInt32 eegRate, UInt32 eegRes, UInt32 memsRate, UInt32 memsRes);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MotionDataUpdateHandle(UInt32 userId, IntPtr hData);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MotionDataGet(IntPtr hData, IEE_MotionDataChannel_t channel, Double[] buffer, UInt32 bufferSizeInSample);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MotionDataGetMultiChannels(IntPtr hData, IEE_MotionDataChannel_t[] channelList, UInt32 nChannel, Double[][] buffer, UInt32 bufferSizeInSample);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MotionDataGetNumberOfSample(IntPtr hData, out UInt32 nSampleOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MotionDataSetBufferSizeInSec(Single bufferSizeInSec);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MotionDataGetBufferSizeInSec(out Single pBufferSizeInSecOut);

	[DllImport("__Internal")]
	public static extern Int32 IEE_MotionDataGetSamplingRate(UInt32 userId, out UInt32 pSamplingRate);

	[DllImport("__Internal")]
	public static extern Int32 IEE_GetAverageBandPowers(UInt32 userId, IEE_DataChannel_t channel, Double[] theta, Double[] alpha, Double[] low_beta, Double[] high_beta, Double[] gamma);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FFTSetWindowingType(UInt32 userId, IEE_WindowingTypes type);

	[DllImport("__Internal")]
	public static extern Int32 IEE_FFTGetWindowingType(UInt32 userId, out IEE_WindowingTypes type);

	[DllImport("__Internal")]
	public static extern Int32 IS_FacialExpressionIsLookingLeft(IntPtr state);

	[DllImport("__Internal")]
	public static extern Int32 IS_FacialExpressionIsLookingRight(IntPtr state);

#endif

#if UNITY_ANDROID
	static AndroidJavaClass jc;
	public static void InitAndroidClass()
	{
		if(jc == null)
			jc = new AndroidJavaClass ("com.emotiv.AndroidPlugin.UnityAndroid");
	}

	private static Int32 IEE_ConnectEpocPlusDevice(int index)
	{
		return jc.CallStatic<int>("IEE_ConnectEpocPlusDevice", index, false);
	}

	private static string IEE_GetEpocPlusDeviceName(int index)
	{
		return jc.CallStatic<string>("IEE_GetEpocPlusDeviceName", index);
	}

	private static string IEE_GetInsightDeviceName(int index)
	{
		return jc.CallStatic<string>("IEE_GetInsightDeviceName", index);
	}
	
	private static Int32 IEE_GetEpocPlusDeviceCount()
	{
		return jc.CallStatic<int>("IEE_GetEpocPlusDeviceCount");
	}

	private static Int32 IEE_ConnectInsightDevice(int index)
	{
		return jc.CallStatic<int>("IEE_ConnectInsightDevice",index);
	}

	private static Int32 IEE_GetInsightDeviceCount()
	{
		return jc.CallStatic<int>("IEE_GetInsightDeviceCount");
	}

	private static Int32 IEE_GetInsightDeviceState(int index)
	{
		return jc.CallStatic<int>("IEE_GetInsightDeviceState",index);
	}

	private static Int32 IEE_GetEpocPlusDeviceState(int index)
	{
		return jc.CallStatic<int>("IEE_GetEpocPlusDeviceState",index);
	}
				
#endif

 public static Int32 Plugin_IEE_ConnectEpocPlusDevice(int index)
	{
#if (UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX)
		return 0;
#else
        Int32 r = IEE_ConnectEpocPlusDevice(index);
        return r;
#endif
    }
    public static string Plugin_IEE_GetEpocPlusDeviceName(int index)
    {
#if (UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX)
		return "";
#else
        return IEE_GetEpocPlusDeviceName(index);
#endif
    }
    public static string Plugin_IEE_GetInsightDeviceName(int index)
    {
#if (UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX)
		return "";
#else
        return IEE_GetInsightDeviceName(index);
#endif
    }
    public static Int32 Plugin_IEE_GetEpocPlusDeviceCount()
	{
#if (UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX)
		return 0;
#else
		return IEE_GetEpocPlusDeviceCount();
#endif
	}
	public static Int32 Plugin_IEE_ConnectInsightDevice(int index)
	{
#if (UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX)
		return 0;
#else
		Int32 r = IEE_ConnectInsightDevice(index);
		return r;
#endif
	}
	public static Int32 Plugin_IEE_GetInsightDeviceCount()
	{
#if (UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX)
		return 0;
#else
		return IEE_GetInsightDeviceCount();
#endif
	}
				
	public static void Plugin_IEE_GetInsightDeviceState(out Int32 state, int index)
	{
#if (UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX)
        state = 0;
	    return ;
#else
	#if UNITY_ANDROID
		state = IEE_GetInsightDeviceState(index);
	#else
		IEE_GetInsightDeviceState(out state, index);
	#endif
#endif
	}

	public static void Plugin_IEE_GetEpocPlusDeviceState(out Int32 state, int index)
	{
#if (UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX)
        state = 0;
	    return ;
#else
	#if UNITY_ANDROID
		state = IEE_GetEpocPlusDeviceState(index);
	#else
        IEE_GetEpocPlusDeviceState(out state, index);
	#endif
#endif
	}

    public static Boolean Plugin_IEE_EmoInitDevice(){
#if (UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_ANDROID)
		return false;
#else
		return IEE_EmoInitDevice();
#endif
	}

#if !(UNITY_IPHONE || UNITY_IOS)	
    public static Int32 IEE_EngineConnect(String security)
    {
        return Unmanged_IEE_EngineConnect(security);
    }

    public static Int32 IEE_EngineRemoteConnect(String szHost, UInt16 port)
    {
        return Unmanged_IEE_EngineRemoteConnect(szHost, port);
    }

    public static Int32 IEE_EngineDisconnect()
    {
        return Unmanged_IEE_EngineDisconnect();
    }

    public static Int32 IEE_EnableDiagnostics(String szFilename, Int32 fEnable, Int32 nReserved)
    {
        return Unmanged_IEE_EnableDiagnostics(szFilename, fEnable, nReserved);
    }

    public static IntPtr IEE_EmoEngineEventCreate()
    {
        return Unmanged_IEE_EmoEngineEventCreate();
    }

    public static void IEE_EmoEngineEventFree(IntPtr hEvent)
    {
        Unmanged_IEE_EmoEngineEventFree(hEvent);
    }

    public static IntPtr IEE_EmoStateCreate()
    {
        return Unmanged_IEE_EmoStateCreate();
    }

    public static void IEE_EmoStateFree(IntPtr hState)
    {
        Unmanged_IEE_EmoStateFree(hState);
    }

    public static IEE_Event_t IEE_EmoEngineEventGetType(IntPtr hEvent)
    {
        return Unmanged_IEE_EmoEngineEventGetType(hEvent);
    }

    public static Int32 IEE_EmoEngineEventGetUserId(IntPtr hEvent, out UInt32 pUserIdOut)
    {
        return Unmanged_IEE_EmoEngineEventGetUserId(hEvent, out pUserIdOut);
    }

    public static Int32 IEE_EmoEngineEventGetEmoState(IntPtr hEvent, IntPtr hEmoState)
    {
        return Unmanged_IEE_EmoEngineEventGetEmoState(hEvent, hEmoState);
    }

    public static Int32 IEE_EngineGetNextEvent(IntPtr hEvent)
    {
        return Unmanged_IEE_EngineGetNextEvent(hEvent);
    }

    public static Int32 IEE_EngineClearEventQueue(Int32 eventTypes)
    {
        return Unmanged_IEE_EngineClearEventQueue(eventTypes);
    }

    public static Int32 IEE_EngineGetNumUser(out UInt32 pNumUserOut)
    {
        return Unmanged_IEE_EngineGetNumUser(out pNumUserOut);
    }

    public static Int32 IEE_SetHardwarePlayerDisplay(UInt32 userId, UInt32 playerNum)
    {
        return Unmanged_IEE_SetHardwarePlayerDisplay(userId, playerNum);
    }

    public static Int32 IEE_HeadsetGetSensorDetails(IEE_InputChannels_t channelId, out IInputSensorDescriptor_t pDescriptorOut)
    {
        return Unmanged_IEE_HeadsetGetSensorDetails(channelId, out pDescriptorOut);
    }

    public static Int32 IEE_HardwareGetVersion(UInt32 userId, out UInt32 pHwVersionOut)
    {
        return Unmanged_IEE_HardwareGetVersion(userId, out pHwVersionOut);
    }

    public static Int32 IEE_SoftwareGetVersion(StringBuilder pszVersionOut, UInt32 nVersionChars, out UInt32 pBuildNumOut)
    {
        return Unmanged_IEE_SoftwareGetVersion(pszVersionOut, nVersionChars, out pBuildNumOut);
    }

    public static Int32 IEE_HeadsetGetGyroDelta(UInt32 userId, out Int32 pXOut, out Int32 pYOut)
    {
        Int32 r =  Unmanged_IEE_HeadsetGetGyroDelta(userId, out pXOut, out pYOut);
        pYOut *= -1;
        return r;
    }

    public static Int32 IEE_HeadsetGyroRezero(UInt32 userId)
    {
        return Unmanged_IEE_HeadsetGyroRezero(userId);
    }

    public static Int32 IEE_GetHeadsetSettings(UInt32 userId, out UInt32 EPOCmode, out UInt32 eegRate, out UInt32 eegRes, out UInt32 memsRate, out UInt32 memsRes)
    {
        return Unmanaged_IEE_GetHeadsetSettings(userId, out EPOCmode, out eegRate, out eegRes, out memsRate, out memsRes);
    }

    public static Int32 IEE_SetHeadsetSettings(UInt32 userId, UInt32 EPOCmode, UInt32 eegRate, UInt32 eegRes, UInt32 memsRate, UInt32 memsRes)
    {
        return Unmanaged_IEE_SetHeadsetSettings(userId, EPOCmode, eegRate, eegRes, memsRate, memsRes);
    }

	
    public static IntPtr IEE_MotionDataCreate()
    {
        return Unmanaged_IEE_MotionDataCreate();
    }

    public static void IEE_MotionDataFree(IntPtr hData)
    {
        Unmanaged_IEE_MotionDataFree(hData);
    }

    public static Int32 IEE_MotionDataUpdateHandle(UInt32 userId, IntPtr hData)
    {
        return Unmanaged_IEE_MotionDataUpdateHandle(userId, hData);
    }

    public static Int32 IEE_MotionDataGet(IntPtr hData, IEE_MotionDataChannel_t channel, Double[] buffer, UInt32 bufferSizeInSample)
    {
        return Unmanaged_IEE_MotionDataGet(hData, channel, buffer, bufferSizeInSample);
    }

    public static Int32 IEE_MotionDataGetMultiChannels(IntPtr hData, IEE_MotionDataChannel_t[] channelList, UInt32 nChannel, Double[][] buffer, UInt32 bufferSizeInSample)
    {
        return Unmanaged_IEE_MotionDataGetMultiChannels(hData, channelList, nChannel, buffer, bufferSizeInSample);
    }

    public static Int32 IEE_MotionDataGetNumberOfSample(IntPtr hData, out UInt32 nSampleOut)
    {
        return Unmanaged_IEE_MotionDataGetNumberOfSample(hData, out nSampleOut);
    }

    public static Int32 IEE_MotionDataSetBufferSizeInSec(Single bufferSizeInSec)
    {
        return Unmanaged_IEE_MotionDataSetBufferSizeInSec(bufferSizeInSec);
    }

    public static Int32 IEE_MotionDataGetBufferSizeInSec(out Single pBufferSizeInSecOut)
    {
        return Unmanaged_IEE_MotionDataGetBufferSizeInSec(out pBufferSizeInSecOut);
    }

    public static Int32 IEE_MotionDataGetSamplingRate(UInt32 userId, out UInt32 pSamplingRateOut)
    {
        return Unmanaged_IEE_MotionDataGetSamplingRate(userId, out pSamplingRateOut);
    }

    public static IntPtr IS_Create()
    {
        return Unmanaged_IS_Create();
    }

    public static void IS_Free(IntPtr state)
    {
        Unmanaged_IS_Free(state);
    }

    public static void IS_Init(IntPtr state)
    {
        Unmanaged_IS_Init(state);
    }

    public static Single IS_GetTimeFromStart(IntPtr state)
    {
        return Unmanaged_IS_GetTimeFromStart(state);
    }

    public static Int32 IS_GetHeadsetOn(IntPtr state)
    {
        return Unmanaged_IS_GetHeadsetOn(state);
    }

    public static Int32 IS_GetNumContactQualityChannels(IntPtr state)
    {
        return Unmanaged_IS_GetNumContactQualityChannels(state);
    }

    public static IEE_EEG_ContactQuality_t IS_GetContactQuality(IntPtr state, Int32 electroIdx)
    {
        return Unmanaged_IS_GetContactQuality(state, electroIdx);
    }

    public static Int32 IS_GetContactQualityFromAllChannels(IntPtr state, out IEE_EEG_ContactQuality_t[] contactQuality)
    {
        Int32 numChannels = EdkDll.IS_GetNumContactQualityChannels(state);
        contactQuality    = new IEE_EEG_ContactQuality_t[numChannels];
        return Unmanaged_IS_GetContactQualityFromAllChannels(state, contactQuality, (UInt32)contactQuality.Length);
    }

    public static IEE_SignalStrength_t IS_GetWirelessSignalStatus(IntPtr state)
    {
        return Unmanaged_IS_GetWirelessSignalStatus(state);
    }

    public static void IS_Copy(IntPtr a, IntPtr b)
    {
        Unmanaged_IS_Copy(a, b);
    }

    public static Boolean IS_EmoEngineEqual(IntPtr a, IntPtr b)
    {
        return Unmanaged_IS_EmoEngineEqual(a, b);
    }

    public static Boolean IS_Equal(IntPtr a, IntPtr b)
    {
        return Unmanaged_IS_Equal(a, b);
    }

    public static void IS_GetBatteryChargeLevel(IntPtr state, out Int32 chargeLevel, out Int32 maxChargeLevel)
    {
        Unmanaged_IS_GetBatteryChargeLevel(state, out chargeLevel, out maxChargeLevel);
    }

    public static IEE_MentalCommandEvent_t IEE_MentalCommandEventGetType(IntPtr hEvent)
    {
        return Unmanged_IEE_MentalCommandEventGetType(hEvent);
    }

    public static IEE_FacialExpressionEvent_t IEE_FacialExpressionEventGetType(IntPtr hEvent)
    {
        return Unmanged_IEE_FacialExpressionEventGetType(hEvent);
    }

    public static Int32 IEE_FacialExpressionSetThreshold(UInt32 userId, IEE_FacialExpressionAlgo_t algoName, IEE_FacialExpressionThreshold_t thresholdName, Int32 value)
    {
        return Unmanged_IEE_FacialExpressionSetThreshold(userId, algoName, thresholdName, value);
    }

    public static Int32 IEE_FacialExpressionGetThreshold(UInt32 userId, IEE_FacialExpressionAlgo_t algoName, IEE_FacialExpressionThreshold_t thresholdName, out Int32 pValueOut)
    {
        return Unmanged_IEE_FacialExpressionGetThreshold(userId, algoName, thresholdName, out pValueOut);
    }

    public static Int32 IEE_FacialExpressionSetTrainingAction(UInt32 userId, IEE_FacialExpressionAlgo_t action)
    {
        return Unmanged_IEE_FacialExpressionSetTrainingAction(userId, action);
    }

    public static Int32 IEE_FacialExpressionSetTrainingControl(UInt32 userId, IEE_FacialExpressionTrainingControl_t control)
    {
        return Unmanged_IEE_FacialExpressionSetTrainingControl(userId, control);
    }

    public static Int32 IEE_FacialExpressionGetTrainingAction(UInt32 userId, out IEE_FacialExpressionAlgo_t pActionOut)
    {
        return Unmanged_IEE_FacialExpressionGetTrainingAction(userId, out pActionOut);
    }

    public static Int32 IEE_FacialExpressionGetTrainingTime(UInt32 userId, out UInt32 pTrainingTimeOut)
    {
        return Unmanged_IEE_FacialExpressionGetTrainingTime(userId, out pTrainingTimeOut);
    }

    public static Int32 IEE_FacialExpressionGetTrainedSignatureActions(UInt32 userId, out UInt32 pTrainedActionsOut)
    {
        return Unmanged_IEE_FacialExpressionGetTrainedSignatureActions(userId, out pTrainedActionsOut);
    }

    public static Int32 IEE_FacialExpressionGetTrainedSignatureAvailable(UInt32 userId, out Int32 pfAvailableOut)
    {
        return Unmanged_IEE_FacialExpressionGetTrainedSignatureAvailable(userId, out pfAvailableOut);
    }

    public static Int32 IEE_FacialExpressionSetSignatureType(UInt32 userId, IEE_FacialExpressionSignature_t sigType)
    {
        return Unmanged_IEE_FacialExpressionSetSignatureType(userId, sigType);
    }

    public static Int32 IEE_FacialExpressionGetSignatureType(UInt32 userId, out IEE_FacialExpressionSignature_t pSigTypeOut)
    {
        return Unmanged_IEE_FacialExpressionGetSignatureType(userId, out pSigTypeOut);
    }

    public static Int32 IEE_MentalCommandSetActiveActions(UInt32 userId, UInt32 activeActions)
    {
        return Unmanged_IEE_MentalCommandSetActiveActions(userId, activeActions);
    }

    public static Int32 IEE_MentalCommandGetActiveActions(UInt32 userId, out UInt32 pActiveActionsOut)
    {
        return Unmanged_IEE_MentalCommandGetActiveActions(userId, out pActiveActionsOut);
    }

    public static Int32 IEE_MentalCommandGetTrainingTime(UInt32 userId, out UInt32 pTrainingTimeOut)
    {
        return Unmanged_IEE_MentalCommandGetTrainingTime(userId, out pTrainingTimeOut);
    }

    public static Int32 IEE_MentalCommandSetTrainingControl(UInt32 userId, IEE_MentalCommandTrainingControl_t control)
    {
        return Unmanged_IEE_MentalCommandSetTrainingControl(userId, control);
    }

    public static Int32 IEE_MentalCommandSetTrainingAction(UInt32 userId, IEE_MentalCommandAction_t action)
    {
        return Unmanged_IEE_MentalCommandSetTrainingAction(userId, action);
    }

    public static Int32 IEE_MentalCommandGetTrainingAction(UInt32 userId, out IEE_MentalCommandAction_t pActionOut)
    {
        return Unmanged_IEE_MentalCommandGetTrainingAction(userId, out pActionOut);
    }

    public static Int32 IEE_MentalCommandGetTrainedSignatureActions(UInt32 userId, out UInt32 pTrainedActionsOut)
    {
        return Unmanged_IEE_MentalCommandGetTrainedSignatureActions(userId, out pTrainedActionsOut);
    }

    public static Int32 IEE_MentalCommandGetOverallSkillRating(UInt32 userId, out Single pOverallSkillRatingOut)
    {
        return Unmanged_IEE_MentalCommandGetOverallSkillRating(userId, out pOverallSkillRatingOut);
    }

    public static Int32 IEE_MentalCommandGetActionSkillRating(UInt32 userId, IEE_MentalCommandAction_t action, out Single pActionSkillRatingOut)
    {
        return Unmanged_IEE_MentalCommandGetActionSkillRating(userId, action, out pActionSkillRatingOut);
    }

    public static Int32 IEE_MentalCommandSetActivationLevel(UInt32 userId, Int32 level)
    {
        return Unmanged_IEE_MentalCommandSetActivationLevel(userId, level);
    }

    public static Int32 IEE_MentalCommandSetActionSensitivity(UInt32 userId,
                                        Int32 action1Sensitivity, Int32 action2Sensitivity,
                                        Int32 action3Sensitivity, Int32 action4Sensitivity)
    {
        return Unmanged_IEE_MentalCommandSetActionSensitivity(userId, action1Sensitivity, action2Sensitivity, action3Sensitivity, action4Sensitivity);
    }

    public static Int32 IEE_MentalCommandGetActivationLevel(UInt32 userId, out Int32 pLevelOut)
    {
        return Unmanged_IEE_MentalCommandGetActivationLevel(userId, out pLevelOut);
    }

    public static Int32 IEE_MentalCommandGetActionSensitivity(UInt32 userId,
                                        out Int32 pAction1SensitivityOut, out Int32 pAction2SensitivityOut,
                                        out Int32 pAction3SensitivityOut, out Int32 pAction4SensitivityOut)
    {
        return Unmanged_IEE_MentalCommandGetActionSensitivity(userId, out pAction1SensitivityOut, out pAction2SensitivityOut,
            out pAction3SensitivityOut, out pAction4SensitivityOut);
    }

    public static Int32 IEE_MentalCommandStartSamplingNeutral(UInt32 userId)
    {
        return Unmanged_IEE_MentalCommandStartSamplingNeutral(userId);
    }

    public static Int32 IEE_MentalCommandStopSamplingNeutral(UInt32 userId)
    {
        return Unmanged_IEE_MentalCommandStopSamplingNeutral(userId);
    }

    public static Int32 IEE_MentalCommandSetSignatureCaching(UInt32 userId, UInt32 enabled)
    {
        return Unmanged_IEE_MentalCommandSetSignatureCaching(userId, enabled);
    }

    public static Int32 IEE_MentalCommandGetSignatureCaching(UInt32 userId, out UInt32 pEnabledOut)
    {
        return Unmanged_IEE_MentalCommandGetSignatureCaching(userId, out pEnabledOut);
    }

    public static Int32 IEE_MentalCommandSetSignatureCacheSize(UInt32 userId, UInt32 size)
    {
        return Unmanged_IEE_MentalCommandSetSignatureCacheSize(userId, size);
    }

    public static Int32 IEE_MentalCommandGetSignatureCacheSize(UInt32 userId, out UInt32 pSizeOut)
    {
        return Unmanged_IEE_MentalCommandGetSignatureCacheSize(userId, out pSizeOut);
    }

    public static Int32 IEE_GetAverageBandPowers(UInt32 userId, IEE_DataChannel_t channel, Double[] theta, Double[] alpha, Double[] low_beta, Double[] high_beta, Double[] gamma)
    {
        return Unmanged_IEE_GetAverageBandPowers(userId, channel, theta, alpha, low_beta, high_beta, gamma);
    }

    public static Int32 IEE_FFTSetWindowingType(UInt32 userId, IEE_WindowingTypes type)
    {
        return Unmanged_IEE_FFTSetWindowingType(userId, type);
    }

    public static Int32 IEE_FFTGetWindowingType(UInt32 userId, out IEE_WindowingTypes type)
    {
        return Unmanged_IEE_FFTGetWindowingType(userId, out type);
    }


    public static Boolean IS_FacialExpressionIsBlink(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionIsBlink(state);
    }

    public static Boolean IS_FacialExpressionIsLeftWink(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionIsLeftWink(state);
    }

    public static Boolean IS_FacialExpressionIsRightWink(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionIsRightWink(state);
    }

    public static Boolean IS_FacialExpressionIsEyesOpen(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionIsEyesOpen(state);
    }

    public static Boolean IS_FacialExpressionIsLookingUp(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionIsLookingUp(state);
    }

    public static Boolean IS_FacialExpressionIsLookingDown(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionIsLookingDown(state);
    }

    public static Int32 IS_FacialExpressionIsLookingLeft(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionIsLookingLeft(state);
    }

    public static Int32 IS_FacialExpressionIsLookingRight(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionIsLookingRight(state);
    }

    public static void IS_FacialExpressionGetEyelidState(IntPtr state, out Single leftEye, out Single rightEye)
    {
        Unmanaged_IS_FacialExpressionGetEyelidState(state, out leftEye, out rightEye);
    }

    public static void IS_FacialExpressionGetEyeLocation(IntPtr state, out Single x, out Single y)
    {
        Unmanaged_IS_FacialExpressionGetEyeLocation(state, out x, out y);
    }

    public static Single IS_FacialExpressionGetEyebrowExtent(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionGetEyebrowExtent(state);
    }

    public static Single IS_FacialExpressionGetSmileExtent(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionGetSmileExtent(state);
    }

    public static Single IS_FacialExpressionGetClenchExtent(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionGetClenchExtent(state);
    }

    public static IEE_FacialExpressionAlgo_t IS_FacialExpressionGetUpperFaceAction(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionGetUpperFaceAction(state);
    }

    public static Single IS_FacialExpressionGetUpperFaceActionPower(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionGetUpperFaceActionPower(state);
    }

    public static IEE_FacialExpressionAlgo_t IS_FacialExpressionGetLowerFaceAction(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionGetLowerFaceAction(state);
    }

    public static Single IS_FacialExpressionGetLowerFaceActionPower(IntPtr state)
    {
        return Unmanaged_IS_FacialExpressionGetLowerFaceActionPower(state);
    }
    public static Boolean IS_FacialExpressionIsActive(IntPtr state, IEE_FacialExpressionAlgo_t type)
    {
        return Unmanaged_IS_FacialExpressionIsActive(state, type);
    }

    public static IEE_MentalCommandAction_t IS_MentalCommandGetCurrentAction(IntPtr state)
    {
        return Unmanaged_IS_MentalCommandGetCurrentAction(state);
    }

    public static Single IS_MentalCommandGetCurrentActionPower(IntPtr state)
    {
        return Unmanaged_IS_MentalCommandGetCurrentActionPower(state);
    }

    public static Boolean IS_MentalCommandIsActive(IntPtr state)
    {
        return Unmanaged_IS_MentalCommandIsActive(state);
    }

    public static Boolean IS_FacialExpressionEqual(IntPtr a, IntPtr b)
    {
        return Unmanaged_IS_FacialExpressionEqual(a, b);
    }

    public static Boolean IS_MentalCommandEqual(IntPtr a, IntPtr b)
    {
        return Unmanaged_IS_MentalCommandEqual(a, b);
    }
#endif
}