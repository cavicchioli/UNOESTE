http://brownbuffalo.sourceforge.net/bprolog/puzzle_index.html
http://www.docstoc.com/docs/13939056/10-Exercicios-de-Prolog-exercises
/* File: canibmm.pl
   Author: (sol) MM
   Title: Missionaries and cannibals

On a river bank there are 3 cannibals and 3 missionaries. 
Here is a boat with 2 places for crossing the river. 
If on a bank there remain more cannibals than missionaries
then it is dangerous, since the cannibals may eat them.

How could they all cross the river without being in danger?

Representation:
Tha bank are labeled s and d. 
You can label as you wish: a and b or 1 and 2 or left and right

A state (node) is:

[Boats_Place,Nr_Miss_s,Nr_Cann_s,Nr_Miss_d,Nr_Cann_d]                  
or short:
[s,Ms,Cs,Md,Cd] - means the boat is on the bank labeled s and 
         on the s bank there are Ms missionaries and Cs cannibals
	 on the d bank there are Md missionaries and Cs cannibals
[d,2,0,1,3] - means the boat is on the bank (d)
              on bank s there are: 2 missionaries and no cannibals
	      on bank d there is 1  missionary and 3 cannibals
              (this is acutally a unacceptable state). 
*/

/* declare the initial state (node)
   declare the final state(node)
*/

initial([s,3,3,0,0]).
final([d,0,0,3,3]).

/* explain the states (nodes) prohibited by my problems.
thise states should be avoided when you look for the path.
*/
 
bad([_,M1,C1,M2,C2]):- (M1>0,M1<C1); (M2>0,M2<C2).

/* 	The problem is reduced to the pattern:
	find for a path in a directed graph.
	The following predicates are almost the same as in graph theory.
        We added the condition (not bad(State) ).
*/

start:- initial(S),rez(S,Path),my_write(Path).

rez(State,Sol):- bkt(State,[],Sol).

bkt(State,Path,[State|Path]):- final(State).
bkt(State,Path,Sol):- arc(State,N1), not bad(N1),
		      not member(N1,Path), bkt(N1,[State|Path],Sol).

/* The art of solving the problem is to describe the arcs.
   After you decided the representation for the states.
*/
/* Find a p[ossible configuration for the boat.
   Take from one bank the configuration, 
   add the configuration to the other bank
*/

arc([s,Ms,Cs,Md,Cd],[d,Ms1,Cs1,Md1,Cd1]):- boat(M,C),
	Ms>=M,Ms1 is Ms-M, Cs>=C,Cs1 is Cs-C, 
	Md1 is Md+M, Cd1 is Cd+C.

arc([d,Ms,Cs,Md,Cd],[s,Ms1,Cs1,Md1,Cd1]):-boat(M,C),       
	Md>=M, Md1 is Md-M, Cd>=C, Cd1 is Cd-C,
	Ms1 is Ms+M, Cs1 is Cs+C.

/* M and C are the numbers of missionaries and cannibals 
   which can compose a boat. Their sum must be < 2.
?- boat(M,C).
M=0
C=1
M=1
C=0
...
boat/2 is a generator.
*/

boat(M,C):-member([M,C],[[0,1],[1,0],[1,1],[2,0],[0,2]]).

/* to write the problem each state on a line */
my_write([]).
my_write([H|T]):- write(H),nl, my_write(T).
/*
 ?- start,nl,nl,fail.
[d,0,0,3,3]
[s,0,2,3,1]
[d,0,1,3,2]
[s,0,3,3,0]
[d,0,2,3,1]
[s,2,2,1,1]
[d,1,1,2,2]
[s,3,1,0,2]
[d,3,0,0,3]
[s,3,2,0,1]
[d,2,2,1,1]
[s,3,3,0,0]

[d,0,0,3,3]
[s,1,1,2,2]
[d,0,1,3,2]
[s,0,3,3,0]
[d,0,2,3,1]
[s,2,2,1,1]
[d,1,1,2,2]
[s,3,1,0,2]
[d,3,0,0,3]
[s,3,2,0,1]
[d,2,2,1,1]
[s,3,3,0,0]

[d,0,0,3,3]
[s,0,2,3,1]
[d,0,1,3,2]
[s,0,3,3,0]
[d,0,2,3,1]
[s,2,2,1,1]
[d,1,1,2,2]
[s,3,1,0,2]
[d,3,0,0,3]
[s,3,2,0,1]
[d,3,1,0,2]
[s,3,3,0,0]

[d,0,0,3,3]
[s,1,1,2,2]
[d,0,1,3,2]
[s,0,3,3,0]
[d,0,2,3,1]
[s,2,2,1,1]
[d,1,1,2,2]
[s,3,1,0,2]
[d,3,0,0,3]
[s,3,2,0,1]
[d,3,1,0,2]
[s,3,3,0,0]

*/