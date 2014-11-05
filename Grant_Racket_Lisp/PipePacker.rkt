#lang racket

(provide pack)

(define (pack binSize pipes)
  (define (add pipe bins)
    (define (fits pipe bin)
      (> (- binSize (apply + bin)) pipe))
    
    (define (fill remainingBins filled)
      (cond
        [filled remainingBins]
        [(empty? remainingBins) (list pipe)]
        ;[else (cons (cons pipe (first remainingBins)) (rest remainingBins))]
        [else (cond
                [(fits pipe (first remainingBins))
                 (cons (cons pipe (first remainingBins)) (rest remainingBins))]
                [else (cons (first remainingBins) (fill (rest remainingBins) #f))])]
        ))
    
    (fill bins #f))
  
  (foldl (lambda (pipe bins)
           (add pipe bins))
         (list (list))
         pipes))
  
