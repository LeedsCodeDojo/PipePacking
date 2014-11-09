-module(binpack).

-export([test/0, testPackOne/0, pack/1, packOne/1]).

test() ->
    {[10],  []} = packOne({binsize,10,pipes,[10]}),
    {[5,5], []} = packOne({binsize,10,pipes,[5,5]}),
    {[6],   [6]} = packOne({binsize,10,pipes,[6,6]}),
    ok.

testPackOne() ->
    {[], [1, 2, 3]} = packOne({binsize, 0, pipes, [1, 2, 3]}),
    {[], []} = packOne({binsize, 10, pipes, []}).

pack({binsize, Binsize, pipes, Pipes}) ->
    SortedPipes = lists:reverse(lists:sort(Pipes)),
    lists:reverse(packAcc({binsize, Binsize, pipes, SortedPipes, binsSoFar, []})).

packAcc({binsize, Binsize, pipes, Pipes, binsSoFar, BinsSoFar}) ->
    {Bin, RemainingPipes} = packOne({binsize, Binsize, pipes, Pipes}),
    if 
        (length(Bin) =:= 0) ->
            BinsSoFar;
        (length(Bin) /= 0) ->
            packAcc({binsize, Binsize, pipes, RemainingPipes, binsSoFar, [Bin|BinsSoFar]})
    end.

% Pack one bin
packOne({binsize, 0, pipes, Pipes}) ->
%    io:format("Binsize: ~w Pipes: ~w~n", [0, Pipes]),
    {[], Pipes};

packOne({binsize, Binsize, pipes, []}) ->
     _ = Binsize,
%    io:format("Binsize: ~w Pipes: ~w~n", [Binsize, []]),
    {[], []};

packOne({binsize, Binsize, pipes, [Pipe|Pipes]}) when (Pipe =< Binsize) ->
%    io:format("Binsize: ~w Pipes: ~w~n", [Binsize, [Pipe|Pipes]]),
    {Bin, RemainingPipes} = packOne({binsize, Binsize - Pipe, pipes, Pipes}),
    {[Pipe|Bin], RemainingPipes};

packOne({binsize, Binsize, pipes, [Pipe|Pipes]}) ->
%    io:format("Binsize: ~w Pipes: ~w~n", [Binsize, [Pipe|Pipes]]),
    {Bin, RemainingPipes} = packOne({binsize, Binsize, pipes, Pipes}),
    {Bin, [Pipe|RemainingPipes]}.
