#lang racket/base

(require rackunit
         "PipePacker.rkt")

(check-equal? (pack 10 (list 8 9 10)) (list (list 8) (list 9) (list 10)) "Pipes returned as lists in bins")

"**********************"
"*** Tests Complete ***"
"**********************"