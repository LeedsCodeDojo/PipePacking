module PackerTests

open Xunit
open FsUnit
open Packer

[<Fact>]
let ``single pipe smaller than bin size gives single bin`` () =
    pack 10 [10] |> should equal [[10]]

[<Fact>]
let ``two pipes bigger than bin size gives two bins`` () =
    pack 10 [6;6] |> should equal [[6];[6]]

[<Fact>]
let ``two pipes smaller than bin size gives one bin`` () =
    pack 10 [5;5] |> should equal [[5;5]]

[<Fact>]
let ``several pipes pack into a reasonable number of bins`` () =
    pack 10 [1;2;3;4;5;6;7;8;9] |> should equal [[1;9];[2;8];[3;7];[4;6];[5]]

[<Fact>]
let ``set of pipes which first fit doesn't solve perfectly`` () =
    pack 10 [2;2;3;4;4;5] |> should equal [[2;4;4];[2;3;5]]