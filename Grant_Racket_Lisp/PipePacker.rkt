#lang racket

(provide pack)

; Returns the list of pipes packed into the minimum number of bins based on binSize.
; Uses the first-fit algorithm.
(define (pack binSize pipes)
  
  (define (add pipe bins)
    
    (define (fits? pipe bin)
      (>= (- binSize (apply + bin)) pipe))
    
    ; try to add the pipe to the list of bins, recursively
    (define (fill remainingBins)
      (if (empty? remainingBins) 
          (list (list pipe)) ; no bins left - stick the pipe in a new one
          (if (fits? pipe (first remainingBins)) ; see if the pipe fits in the current bin
                 (cons (cons pipe (first remainingBins)) (rest remainingBins)) ; pipe fits - add it
                 (cons (first remainingBins) (fill (rest remainingBins)))))) ; pipe doesn't fit - keep trying the rest
    
    (fill bins))
  
  ; go through reverse-sorted pipes, adding each to the growing collection of bins
  (foldl (lambda (pipe bins) (add pipe bins))
         (list)
         (sort pipes >)))