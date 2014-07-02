Rotten
======

cmdlet to search Rotten Tomatoes.
Requires Newtownsoft JSON.net

####Returns 
* Year released
* MPAA rating
* Runtime
* Critics score
* Critics rating
* Audience score

####Usage
Searching for a movie:
`Rotten Speed` returns
<pre>
MPAA Rating: R
Runtime: 1:55
Critics Rating: Certified Fresh
Critics Score: 93
Audience Score: 75
</pre>
Enter multiple movies:
`Rotten "Speed" "Air Force One" "Sunshine"`
<pre>
Searching Rotten Tomatoes...

Speed (1994)
------------
MPAA Rating: R
Runtime: 1:55
Critics Rating: Certified Fresh
Critics Score: 93
Audience Score: 75


Air Force One (1997)
--------------------
MPAA Rating: R
Runtime: 2:04
Critics Rating: Certified Fresh
Critics Score: 79
Audience Score: 66


Sunshine (2007)
---------------
MPAA Rating: R
Runtime: 1:47
Critics Rating: Certified Fresh
Critics Score: 75
Audience Score: 73
</pre>
####To do
* Rewrite to not require additional libraries
