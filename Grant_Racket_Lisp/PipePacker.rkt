#lang racket/base

(define (pack binSize pipes)
  ;(map (lambda (pipe) (list pipe)) pipes))
  (map list pipes))
  
(provide pack)