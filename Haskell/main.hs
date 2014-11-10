module Sort where

nextBin	:: (Num a, Ord a) => a -> [a] -> [a] -> ([a], [a])
nextBin _ [] box = (box, [])
nextBin size remenants@(item:items) box = 
	if (foldl (+) item box) <= size
		then nextBin size items (item:box)
		else (box, remenants)

getBin :: (Num a, Ord a) => a -> [a] -> [[a]]
getBin _ [] = []
getBin bin_size allItems = 
	let next = nextBin bin_size	allItems []
	in (fst next) : getBin bin_size (snd next)