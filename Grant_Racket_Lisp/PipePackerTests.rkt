#lang racket

(require rackunit
         "PipePacker.rkt")

(check-equal? (pack 10 (list 10)) (list (list 10)) "Small pipe put into single bin")

(check-equal? (pack 10 (list 5 5)) (list (list 5 5)) "Two small pipes put into single bin")

(check-equal? (pack 10 (list 6 6)) (list (list 6) (list 6)) "Two large pipes put into two bins")

(check-equal? (pack 10 (list 1 2 3 4 5 6 7 8 9)) (list (list 1 9) (list 2 8) (list 3 7) (list 4 6) (list 5)) "Mix of pipes combined correctly")

"**********************"
"*** Tests Complete ***"
"**********************"