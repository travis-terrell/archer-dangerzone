//---------------------------------------------------------------------------------------------------------------------------
// Now parse string variables to NameValueCollection
//x  --I need to use dictionary, not NameValueCollection.  Converting NVC -> dictionary shouldn't make things more efficient.
//x    --Can I use HTTPUtility.ParseQueryString(paramString) to add to dictionary?
//---------------------------------------------------------------------------------------------------------------------------

//! Apparently, we don't need a dictionary after all.  Let's just save this code snippet for future optimizations.        
// var input = "paramString";
// var items = input.Split(new[] { '&' });
// var dict = items.Select(item => item.Split(new[] {'='})).ToDictionary(pair => pair[0], pair => pair[1]);
// Create new dictionary to hold parameter key-value pairs.
// Dictionary<string, string> incomingDict = new Dictionary<string, string>();
// Reference: http://www.dotnetperls.com/dictionary