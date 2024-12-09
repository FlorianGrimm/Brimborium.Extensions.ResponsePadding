# Brimborium.Extensions.ResponsePadding

Experiment: random response padding to enable compression

**This is an experiment. This is NOT a security advice. This is NOT productive code.**

Enabling compression on a HTTPS streams allows a TLS CRIME attack.

Compression might be a big performance boost, since the network communication takes more time than a compression of a response.

My understanding of the TLS CRIME attack is:
A hacker stablished a man in the middle attack (DNS shenanigans) and reroute the packets to the evil server, and do not temper the tls stream, the server has information about the size of the content.
So if he can modify the parameter he can temper with size of the response, since the same text will be caught by the compression and might guess the cookie / websession value.

I don't understand:
If the attacker didn't affect the victims computer - how can he send a second request or modify the url?
If the attacker did affect the victims computer - can't he just read the browsers cookie store?

So how can we fight against this?
a random text in each response? .. prone to errors/forget?
do not use cookies and websession? .. a challenge?


First ideas:

For auth a cookie is used - can I send each time a different cookie - how does the server not struggle on this - especially for scaled out server farms.

Allow responses only if a (ASP.Net Core -) feature allows it.
  - allowed for anonymous requests.
  - allowed for static files.

Add a random text 
  - on which responses? only 200? 
  - add a random header and a random nonce at the top and end?

Steps:

  - better understanding of the attack

  - What does app.UseResponseCompression(); really do?
    - IHttpsCompressionFeature


And again:
**This is an experiment. This is NOT a security advice. This is NOT productive code.**
