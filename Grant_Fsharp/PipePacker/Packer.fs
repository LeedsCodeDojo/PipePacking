module Packer

// Return pipes packed into the minumum number of bins based on binSize.
// Uses the first-fit algorithm
let pack binSize pipes =
    
    let spaceRemaining bin = binSize - List.sum bin

    // Add a pipe to the collection of bins
    // Put it in the first bin with enough space, otherwise use a new one
    let add pipe bins =
        let rec getPackedBins bins pipeAdded =
            match pipeAdded,bins with
            | false, bin::rest -> 
                match bin |> spaceRemaining with
                | space when space >= pipe -> (pipe::bin)::(getPackedBins rest true) // bin has space - add pipe
                | _ -> bin::(getPackedBins rest false) // no space in bin - try the rest
            | false, [] -> [[pipe]] // no bins left - put pipe in a new one
            | true, remainingBins -> remainingBins // pipe already packed - nothing to do
        getPackedBins bins false

    // iterate through the pipes, adding each to the collection of bins
    let rec fillBins bins remainingPipes =
        match remainingPipes with
        | pipe::rest -> fillBins (bins |> add pipe) rest // take the first pipe and add it to the bins
        | [] -> bins // all pipes packed!
    
    let sortedPipes = pipes |> List.sort |> List.rev

    fillBins [] sortedPipes