fun sq int = int * int;
(* 
fun sqsum (x::xs) = x*x + sqsum xs | sqsum [] = 0;

fun cycle([],x) = []
| cycle(hd::tl,x) = if(x = 0) then hd::tl else cycle( tl@[hd], (x - 1));

fun semrev([],x) = []
| semrev(hd::tl, x) if (x = 0) then hd::tl else semrev(tl@[x], (x - 1)); *)