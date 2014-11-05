#lang racket

(require rackunit
         "PipePacker.rkt")

(check-equal? (pack 10 (list 10)) (list (list 10)) "Small pipe put into single bin")
(check-equal? (pack 10 (list 5 5)) (list (list 5 5)) "Two small pipes put into single bin")
(check-equal? (pack 10 (list 6 6)) (list (list 6) (list 6)) "Two large pipes put into two bins")

"**********************"
"*** Tests Complete ***"
"**********************"