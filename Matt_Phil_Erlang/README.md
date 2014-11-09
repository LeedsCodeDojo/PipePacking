
Usage
-----

From the erlang shell, you can compile and run as so:

```erlang

[snapper dojo]$ erl
Erlang R16B03-1 (erts-5.10.4) [source] [64-bit] [smp:2:2] [async-threads:10] [hipe] [kernel-poll:false]

Eshell V5.10.4  (abort with ^G)
1> c(binpack).
{ok,binpack}
2> binpack:test().
ok
3> binpack:pack({binsize, 10, pipes, [3,4,5,6]}).
[[6,4],[5,3]]
4> 
4> q().
ok
5>
[snapper dojo]$


``` 

Note that Erlang modules must be in a file with the same name, ie `binpack` must be in a file named
`binpack.erl`.  The `c(binpack).` stage compiles the `.erl` file into a `.beam`, which is run in
the Erlang VM.
