#
# Sinch Server SDK NuGet package
# Version: 1.3.0
This package supports

	- Signing and making API REST calls to the Sinch backend
	- Authenticating and interpreting callbacks from the Sinch Backend
	- Constructing and signing replies to callbacks from the Sinch Backend

# Contents
1. Calling Callbacks
1. Calling Callbacks - Responding
1. Indications
1. Defining Menu Structures
1. Callouts
1. Fluent
1. Examples

## Calling Callbacks
In this section, we describe how to use this package for parsing/interpreting calling callback events and creating callback replies, a.k.a. "SVAMLets". For more information on the Sinch calling callback model and SVAML - see the REST callback documentation.

### Interpreting a request

Depending on your server implementation, you either get and return a string or get and return a JSON-serializable  object. Should you get a string, the library offers

	ICallbackEvent ReadJson(string json);

Should you get an object you should use the model provided by the library:

	CallbackEventModel

and then use

	ICallbackEvent ReadModel(CallbackEventModel model);

Both methods are implemented by the CallbackResponseFactory, so start by instantiating that:

		var sinch = SinchFactory.CreateCallbackResponseFactory(Locale.EnUs);

You can use this object as a singleton (single instance) for every locale you need to support.

###Example
An OWIN example

    [Route("sinchcallback")]
    public async Task<SvamletModel> Post([FromBody] CallbackEventModel callbackEvent)
    {
		var sinch = SinchFactory.CreateCallbackResponseFactory(Locale.EnUs);
		var reader = sinch.CreateEventReader();
        var evt = reader.ReadModel(callbackEvent);
		... 
    }


### Interpreting Events

Having read the event (as string or using the model), the returned object implements the ICallbackEvent interface. Given the event type, you can cast it to

	IIceEvent
	IAceEvent
	IPieEvent
	IDiceEvent
	INotificationEvent

#### ICallbackEvent - Common to all Events
	
##### string ApplicationKey
The key of the application that triggered the callback. This corresponds to the application in the Sinch portal that you sat the callback URL for. One URL can be used for many applications, so this is the way you can tell them apart.

##### string CallId
A unique identifier for the call - will be present in all callbacks for the call and in CDRs.

##### IDictionary<string,string> Cookies [*Experimental*]
During a callback session, you can set cookie values that survive between callbacks. A cookie has a string id and a string value (key/value pairs).

Limitations: The id of a cookie cannot be longer that 50 characters. The sum of the size of all cookie values cannot be bigger than 1k characters. These limitations are currently not enforced by this library, but will be enforced by the Sinch backend.

##### string Custom
This is the string data that you supplied when initiating the call - either when placing the call in the client SDK or when initiating the call using the Sinch REST API. This data will also end up in any CDR associated with the call.

##### Event Event

    public enum Event
    {
        Unknown,
        Unspecified,
        IncomingCall,
        AnsweredCall,
        DisconnectedCall,
        PromptInput,
        Notification
    }

This indicates the type of the incoming event

##### string TimeStamp
A timestamp indicating when the event was sent from the Sinch backend. Is UTC and formatted according to the ISO-8061 standard.

##### string User
The user name for the user that initiated the call (if any)

##### int Version
Currently always 1

#### IIceEvent
	
##### ICli Cli
The CLI - Caller Id - of the caller.

	string AlphaNumeric (example: "Bjorn")
	string Numeric (example: "+4612341234")
	string Full (example: "Bjorn <+4612341234>")
	CliMode Mode

A CLI be either public and then have a numeric (phone number) and/or a alphanumeric part, or be hidden as indicated by the CliMode:

    public enum CliMode
    {
        Hidden,
        Numeric,
        AlphaNumeric,
        Full
    }

##### IIdentity To
Represent the destination (if any) that the caller called.

    EndpointType Type - see below
    string Endpoint - the destination in the contex of the EndpointType

    public enum EndpointType
    {
        Username,
        PstnNumber,
        Email,
        Unspecified,
        Unknown
    }

##### OriginationType OriginationType

    public enum OriginationType
    {
        Mxp,
        Pstn,
        Server,
        Unknown,
        Unspecified
    }

##### IMoney Rate

Indicates the PSTN termination rate should the call be connected to the requested destination

    decimal Amount (minute rate)
    string CurrencyId ("USD")


#### IAceEvent

An ACE event does not have any additional properties

#### IPieEvent

A PIE event indicates DTMF input from a user and is the result of a "RunMenu" SVAMLet (see below)


##### MenuId
As specified by the "RunMenu" SVAMLet

##### IMenuResult Result

    MenuResultType Type

The type of the result:

        Error,
        Return,
        Timeout,
        Hangup,
        Unknown,
        Unspecified

The actual value for the result (see "RunMenu" SVAMLet)

    string Value

#### IDiceEvent

The duration of the call
	
	TimeSpan Duration

The result of the call

        Result Result

        Failed,
        Answered,
        Busy,
        NoAnswer,
        NotApplicable,
        Unspecified,
        Unknown,
        Canceled

The reason for the result

        Reason Reason

        Error,
        Answered,
        Busy,
        NoAnswer,
        NotApplicable,
        Unspecified,
        Unknown,
        CallerHangup,
        CalleeHangup,
        ManagerHangup,
        Timeout

The debited amount for the PSTN termination (if any)

        IMoney Debit

The rate for the PSTN termination (if any)

        IMoney Rate

What cli was set for the PSTN termination (if any)

        string From

Where was the call (to be) connected

        IIdentity To

## Calling Callbacks - Responding

You start by instantiating a "builder" object. Depending on what event you are responding to, you should create different builders. Create the builder by calling

        IIceSvamletBuilder CreateIceSvamletBuilder()

or

        IAceSvamletBuilder CreateAceSvamletBuilder()

and then build the response by operating on the returned object. Having built the response you end by calling "Build" to get an ISvamletResponse. Depending on your server implementation, you then response by using the model (Model) or string (Body) of that object.

When responding to a DiCE or Notification, you cannot control anything in the response and hence you directly get a 
ISvamletResponse object:

        ISvamletResponse CreateDiceResponse()
        ISvamletResponse CreateNotificationResponse()

Are you building a SVAMLet to use for PATCHing a call using the Sinch REST API, you create a builder through.

        IManageCallSvamletBuilder CreateManageCallSvamletBuilder()

A SVAMLet has a number (that can be 0) of "instructions" and one "action". 

### Building an ICE response

#### Instructions

##### Say(string text)
Will render an instruction to play a prompt to the caller by using text-to-speech on the specified text. The maximum number of TTS characters of a SVAMLet is 200 (which is enforced by this library).

##### Play(string files)
If you have uploaded pre-recorded prompts you can play them using the "Play" instructions. Multiple files can be specified by separating them by ";".

##### SetCookie(string name, string value) [*Experimental*]
Sets a cookie for the call that will be present in the next callback event (ACE or DiCE).

#### Actions

##### Hangup
Hangs up the call (after having executed any instructions)

#### Hangup(HangupCause cause) [*Experimental*]
Hangs up the call (after having executed any instructions and indicated busy/congestion to the user)

##### Continue
If this is a call initiated from the an SDK client, the call will be connected as requested by the client. If you want to override the behaviour, you should specify another action.

##### ConnectPstn(string number)
Connect the call to a PSTN destination specified by "number".

The returned object supports manipulating the PSTN call:

###### WithCli(string cli) - sets the CLI for the call
###### WithAnonymousCli() - sets hidden CLI for the call
###### WithBridgeTimeout(TimeSpan timeSpan) - sets timeout, in seconds - how long can the call be connected for (max 4 hours)
###### WithDialTimeout(TimeSpan timeSpan) [*Experimental*] - sets timeout for ringing - after how  long trying to connect, should the call attempt be cancelled
###### WithOptimizedDialTimeout() - undocumented for now
###### WithOptimizedDialTimeout() - undocumented for now
###### WithCallbacks() - enable callbacks for the rest of the call (default)
###### WithoutCallbacks() - disable callbacks for the rest of the call
###### WithIndications(string indications) [*Experimental*] - set the tone standard for progress/busy/congestion - see "indications" below - default is "us"
###### WithRecording() - enable recording of the call - you will need to contact Sinch to setup the destination of your recorded filed
###### WithoutRecording() - disable recording (default)


##### ConnectMxp(string user)
Connect the call to a app destination specified by "user". Note that this is currently an unsupported feature and it does not do any GCM/APN pushes.

The returned object supports manipulating the MXP call:

###### WithCli(string cli) - sets the CLI for the call
###### WithAnonymousCli() - sets hidden CLI for the call
###### WithIndications(string indications) [*Experimental*] - set the tone standard for progress/busy/congestion - see "indications" below - default is "us"
###### WithRecording() - enable recording of the call - you will need to contact Sinch to setup the destination of your recorded filed
###### WithoutRecording() - disable recording (default)

##### ConnectMxp(Identity identity)
Connect the call to a app destination specified by "identity". Note that this is currently an unsupported feature and it does not do any GCM/APN pushes.

##### ConnectSipDestination(string sipUri)
Connect the call to a SIP destination. Example: ConnectSipDestination("123123123@mySipServer:5070")

The returned object supports manipulating the MXP call:

###### WithCli(string cli) - sets the CLI for the call
###### WithAnonymousCli() - sets hidden CLI for the call
###### WithIndications(string indications) [*Experimental*] - set the tone standard for progress/busy/congestion - see "indications" below - default is "us"
###### WithRecording() - enable recording of the call - you will need to contact Sinch to setup the destination of your recorded filed
###### WithoutRecording() - disable recording (default)

##### ConnectRegisteredSipPeer(string authName)
Connect the call to a SIP a registered SIP peer (register with an account supplied by Sinch or by using your application's application key and secret

The returned object supports manipulating the MXP call:

###### WithCli(string cli) - sets the CLI for the call
###### WithAnonymousCli() - sets hidden CLI for the call
###### WithExtension(string extension) - will replace the user name in the SIP-uri with the supplied extension
###### WithIndications(string indications) [*Experimental*] - set the tone standard for progress/busy/congestion - see "indications" below - default is "us"
###### WithRecording() - enable recording of the call - you will need to contact Sinch to setup the destination of your recorded filed
###### WithoutRecording() - disable recording (default)

##### ConnectConference(string conferenceId)
Connects the call to a server-side conference

##### Park(string holdPrompt, TimeSpan timeout)
Parks the call while playing the holdprompt repeatalby. The timeout indicates when the park should timeout (but it will always play the entire prompt before timing out, so the actual timeout will be longer). To "unpark" a call, you need to PATCH the call using the Sinch REST API. Note that this is currently an unsupported feature.

##### RunMenu(string menuId, IMenuBuilder menuDefinition)
Executes an IVR menu (specified by menuId). The menu structure must have been defined in advanced by using the menu definition functionality in an IMenuBuilder - see "Defining Menus" below.

#### Building an ACE response

An ACE response has somewhat different support depending on in what context you are using it:

- If the ACE is an event triggered by an answered call to the PSTN, The ACE response can only play prompts/menus, hangup the call or continue (see Hangup and Continue under "Building an ICE response").
- If the ACE is an event triggered for a server-initiated call, the ACE response can be a Hangup, a ConnectConf or a Park

##Indications [*Experimental*]
"connectMxp", "connectSipDestination"/"connectRegisteredSipPeer" and "connectPstn" supports different indications standards (the way progress/busy/congestions sounds). The following standards are supported: at, au, be, br, ch, cl, cn, cz, de, dk, ee, es, fi, fr, gr, hu, it, lt, mx, ml, no, nz, pl, pt, ru, se, sg, uk, us, us-old, tw, ve and za

## Defining menu structures
You define menus by calling BeginMenuDefinition on an IMenuBuilder:

	IMenu BeginMenuDefinition(string menuId, string prompt, string repeatPrompt = null, int repeats = 3)

	string menuId - the unique id of the menu (within this SVAMLet response)
	string prompt - the prompt to play
	string repeatPrompt = null
	int repeats = 3

The "prompt" will be played first. If no DTMF response is detected a prompt will be repeated (but no more that "repeats" times). If a "repeatPrompt" is specified, that will be used, otherwise the "prompt" will be repeated.

To the returned menu, you can add menu options. If you want a menu option that  jumps to another menu, call

        IMenu AddGotoMenuOption(Dtmf option, string targetMenuId, IDictionary<string,string> cookies = null)

If you want a menu options that triggers a PIE event, call (the specified "result" will be added to the PIE event):

        IMenu AddTriggerPieOption(Dtmf option, string result);

### Defining menus for number sequence input
You can define a number sequence input menu by calling AddNumberInputMenu on an IMenuBuilder

	IMenuBuilder AddNumberInputMenu(string menuId, string prompt, int maxDigits, string repeatPrompt = null, int repeats = 3)

### Menu prompts
Any menu prompt (as specified in AddNumberInputMenu or BeginMenuDefinition) can be a number of prompt definitions separated by ";". A prompt definition can be a file name of an uploaded prompt file or a text-to-speech (TTS) string. A TTS string is identified by wrapping the text in "#tts[]" where you enter you text between the brackets.

## Callouts
You can instruct the Sinch backend to place outgoing calls. When that outgoing call is answered, a few typical scenarios are supported-

- Reading a message to the callee
- Sending the callee to a conference room
- Presenting the callee with IVR options to respond to (using DTMF)

To place such calls, you use the Callout API of this Nuget

            
    var calloutApi = SinchFactory.CreateApiFactory("f429b49...", "ui8/...").CreateCalloutApi();

### Reading a message to the callee
You need to supply a destination phone number, a text message and an optional caller id.

    var calloutResponse = await calloutApi.TtsCallout("+15612600684", "how are you doing", "").Call();

### Sending the callee to a conference room
You need to supply a destination phone number, a conference room id, an optional greeting text message and an optional caller id.

    var calloutResponse = await calloutApi.ConferenceCallout("+15612600684", "#4711", "private", "Welcome").Call();

### Presenting the callee with IVR options to respond to (using DTMF)
First, you need to create and define your menu structure using the IMenuBuilder (see "Defining menu structures"). You also need to supply a destination phone number, a cli, a startmenu (pointing to a menu in the defined menu structure and a max call duration.

    var calloutResponse = await calloutApi.MenuCallout("+15612600684", "private", menuBuilder, "main", TimeSpan.FromMinutes(1)).Call();

## Fluent
The package support a "fluent" style of creating responses - see the example section.

## Examples
### Interpreting an incoming event

	var factory = SinchFactory.CreateCallbackResponseFactory(Locale.EnUs);
	var evtParser = factory.CreateEventReader();
	var evt = evtParser.ReadJson(svaml);

	var iceEvent = evt as IIceEvent;
	
	if (iceEvent != null) // or check evt.Event
	{
		var cli = iceEvent.Cli;
		Console.WriteLine("ICE event from " + cli);
	}

### Createing an ICE response - plain style

    var svamletBuilder = factory.CreateIceSvamletBuilder();

    svamletBuilder.SetCookie("c1", "v1");
    svamletBuilder.SetCookie("c2", "v2");
    svamletBuilder.Say("Hello world!");
    svamletBuilder.Hangup();
	
	var toReturnString = svamletBuilder.Build().Body;

	// or

	var toReturnModel = svamletBuilder.Build().Model;


### Createing an ICE response - fluent style

	var toReturnString =
			factory.CreateIceSvamletBuilder()
                .SetCookie("c1", "v1")
                .SetCookie("c2", "v2")
                .Say("Hello world!")
                .Hangup().Body;

### Defining a menu

    menuBuilder.BeginMenuDefinition("xyc", "#TTS[Welcome]")
        .AddGotoMenuOption(Dtmf.Digit0, "xyc", new Dictionary<string, string>() { { "c1", "v1"}})
        .AddGotoMenuOption(Dtmf.Digit1, "xyz")
        .AddTriggerPieOption(Dtmf.Digit2, "returned")
        .EndMenuDefinition();

    menuBuilder.AddNumberInputMenu("xyz", "#TTS[Enter 12 digits]", 12);
