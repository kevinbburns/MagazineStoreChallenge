<html>

<head>
<meta http-equiv=Content-Type content="text/html; charset=windows-1252">
<meta name=Generator content="Microsoft Word 15 (filtered)">
<style>
<!--
 /* Font Definitions */
 @font-face
	{font-family:Wingdings;
	panose-1:5 0 0 0 0 0 0 0 0 0;}
@font-face
	{font-family:"Cambria Math";
	panose-1:2 4 5 3 5 4 6 3 2 4;}
@font-face
	{font-family:Calibri;
	panose-1:2 15 5 2 2 2 4 3 2 4;}
@font-face
	{font-family:"Calibri Light";
	panose-1:2 15 3 2 2 2 4 3 2 4;}
 /* Style Definitions */
 p.MsoNormal, li.MsoNormal, div.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:8.0pt;
	margin-left:0in;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;}
h1
	{mso-style-link:"Heading 1 Char";
	margin-top:12.0pt;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:0in;
	line-height:107%;
	page-break-after:avoid;
	font-size:16.0pt;
	font-family:"Calibri Light",sans-serif;
	color:#2F5496;
	font-weight:normal;}
span.Heading1Char
	{mso-style-name:"Heading 1 Char";
	mso-style-link:"Heading 1";
	font-family:"Calibri Light",sans-serif;
	color:#2F5496;}
.MsoChpDefault
	{font-family:"Calibri",sans-serif;}
.MsoPapDefault
	{margin-bottom:8.0pt;
	line-height:107%;}
@page WordSection1
	{size:8.5in 11.0in;
	margin:1.0in 1.0in 1.0in 1.0in;}
div.WordSection1
	{page:WordSection1;}
 /* List Definitions */
 ol
	{margin-bottom:0in;}
ul
	{margin-bottom:0in;}
-->
</style>

</head>

<body lang=EN-US style='word-wrap:break-word'>

<div class=WordSection1>

<h1><b>#MagazineStoreChallenge </b></h1>

<h1>Summarize the project and what problem it was solving.</h1>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>I was interviewing for a position at a company as a Senior .Net/C#
Programmer; during the process, they had tasked me with some homework. The task
was to consume a remote RESTful .Net Core Web.API, and grab a list of magazines,
categories, and clients associated with both. The remote resource was set up on
a few different end-points. As an included bonus, they would randomly slow down
calls to the server to simulate real-world CPU spikes. Whoever could capture
and aggregate the data fastest moved on to the final round of interviews. </p>

<h1>What did you do particularly well?</h1>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>The two main things that I did exceptionally well were reading
the included instructions and “multi” tasking. After moving on to the final round
and given an offer letter, I had a chance to discuss the other developers'
results with the teams. Most of the developers interviewing did not comprehend
how they should handle calls being slowed down randomly. They also did each
instruction one-by-one, instead of following Microsoft’s TAP framework, which
consists of asynchronous tasks (aka, threads,) and calling multiple end-points,
and running the data through an algorithm in a parallel process. Out of all the
submitted code, mine ran the fastest.</p>

<h1>Where could you enhance your code? How would these improvements make your
code more efficient, secure, and so on?</h1>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>I feel like the code on the “client” side is about as fast
as it will get in a language like C#. But, the Web.API did not require any header-checking
or authentication. Public-facing or not, it is always a good idea to require
some JSON token, at least to prevent a robot crawler or malicious user.</p>

<h1>Did you find writing any piece of this code challenging, and how did you
overcome this? What tools and/or resources are you adding to your support
network?</h1>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>The hardest part of the challenge was trying to compensate
for the calls that would be slowed down. My first thought was to use some sort
of timer and track the calls. But I switched over to a task-based system, which
would call the required end-points, and wait for them in a single task,
allowing me to create multiple jobs. Each task will complete and push the data
into a final list, allowing me to loop through the end-results to output the console
data.</p>

<h1>What skills from this project will be particularly transferable to other
projects and/or course work?</h1>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>Many projects will require a developer to write code that
runs asynchronously in threads to prevent blocking a GUI or minimize time spent
on tasks. </p>

<h1>How did you make this program maintainable, readable, and adaptable?</h1>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>I had used an N-Tier development style. I created a service-tier
to communicate with the remote servers, a data-tier that contained all of my
facets, business models, and interfaces, and finally, a logic/presentation-teir
to output all of the results. The above code could be modified and ingested for
multiple projects, including web and UI. The interfaces could be used with
external projects, mitigating the need for rewriting the code numerous times. I
also added comments on tasks and functions to follow my code and reuse it in
another project or make changes quickly.</p>

<h1>Instructions</h1>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>The source code respository of a proposed programming
challenge.</p>

<p class=MsoNormal>After downloading and compiling the code, begin by executing
the application. The command line will prompt you with the following:</p>

<p class=MsoNormal>Enter in a number for times to execute the request[1-20] or
[E] to exit:</p>

<p class=MsoNormal>Enter a number between 1 and 20 to begin.</p>

<p class=MsoNormal>After a short period, you will be presented with similar
data(depending on your CPU and network speed, your results might vary):</p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>Fastest Time To Complete: 00:00:04.1147600  </p>

<p class=MsoNormal>Slowest Time To Complete: 00:00:08.1492368 </p>

<p class=MsoNormal>Average Time To Complete: 00:00:05.8520850 </p>

<p class=MsoNormal>Number of attempts successful: 10  </p>

<p class=MsoNormal>Number of attempts unsuccessful: 0 </p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>If you are presented with this:</p>

<p class=MsoNormal>There was a system failure; please review the logs in the
Logs folder.</p>

<p class=MsoNormal>Navigate to the folder that contains the executable file; it
will now have a folder labeled &quot;Logs&quot; and include the contents of the
exception.</p>

<h1>&nbsp;</h1>

<h1>&nbsp;</h1>

</div>

</body>

</html>
