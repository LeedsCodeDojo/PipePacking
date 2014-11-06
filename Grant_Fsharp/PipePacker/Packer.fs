module Packer

// Return pipes packed into the minumum number of bins based on binSize.
// Uses the first-fit algorithm
let pack binSize pipes =
    
    // Add a pipe to the collection of bins
    let add pipe bins =

        let fits bin pipe = (binSize - List.sum bin) >= pipe

        let rec fill bins =
            match bins with
            | [] -> [[pipe]] // no bins left - put pipe in a new one
            | bin::rest -> 
                if pipe |> fits bin
                then (pipe::bin)::rest // bin has space - add pipe
                else bin::(fill rest) // no space in this bin - try the rest
            
        fill bins

    pipes 
    |> List.sortBy (~-)
    |> List.fold (fun bins pipe -> bins |> add pipe) []