#!/usr/bin/env bash

pandoc readme.md -f markdown -t pdf --pdf-engine=pdflatex -s -o "Exercise People Counter.pdf"
