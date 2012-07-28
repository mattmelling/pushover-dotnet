pushover-dotnet
===============

.NET Wrapper around [Pushover.net](http://www.pushover.net).

##Quick start##

Get an [API key](https://pushover.net/apps/build).

    var client = new PushoverClient("api-key");
    client.Push(new PushoverMessageBase
    {
        User = "user-key",
        Message = "Hello from Pushover!"
    });

##Errors##

    try 
    {
        var client = new PushoverClient("api-key");
        client.Push(new PushoverMessageBase
        {
            User = "user-key",
            Message = "Hello from Pushover!"
        });   
    }
    catch(ArgumentException ae)
    {
        // Thrown if you pass in a null message or null/empty user key
    }
    catch(PushoverException pe)
    {
        // Thrown if there is a problem sending the message
        Logger.Error(pe.Message);
    }

##Additional message properties##

    var client = new PushoverClient("api-key");
    client.Push(new PushoverMessageBase
    {
        User = "user-key",
        Message = "Hello from Pushover!",
        Title = "Test Message",
        Url = "http://pushover.net",
        UrlTitle = "Pushover",
        Priority = MessagePriority.High,
        Timestamp = DateTime.Now
    });