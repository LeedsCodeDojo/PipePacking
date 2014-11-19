module Pipe where
import Test.QuickCheck
import Test.Hspec

--myFunc :: a -> [c] -> [d] -> [e]
--myFunc bin_size (box:boxes) acc = if ((sum acc) + box < bin_size) then acc:box else acc

putInBox :: (Num a, Ord a) => a -> [a] -> [a] -> [a]
putInBox bin_size [] box = box
putInBox bin_size (item:items) box = 
    if ((sum box) + item <= bin_size)
        then item:box
        else box

putInBox2 :: (Num a, Ord a) => a -> [a] -> [a] -> [a]
putInBox2 bin_size [] box = box
putInBox2 bin_size (item:items) box = 
    if ((sum box) + item <= bin_size)
        then putInBox2 bin_size items (item:box)
        else box

putInBox3 :: (Num a, Ord a) => a -> [a] -> [a] -> ([a], [a])
putInBox3 bin_size [] box = ([], box)
putInBox3 bin_size (item:items) box = 
    if ((sum box) + item <= bin_size)
        then (putInBox3 bin_size items (item:box))
        else ((item:items), box)

--putInBox4 :: (Num a, Ord a) => a -> [a] -> [a] -> ([a], [a])
--putInBox4 bin_size [] box = 
--    if sum box <= bin_size -- hmm, not here?
--        then error "Cannot fix item in bin"
--        else ([], box)
--putInBox4 bin_size (item:items) box = 
--    if ((sum box) + item <= bin_size)
--        then (putInBox4 bin_size items (item:box))
--        else ((item:items), box)

--out = myFunc2 10 [1,2,3] [1:2]

-- getBin :: (Num a) => a -> [a] -> [[a]]

-- getBin bin_size pipes = foldr (\x acc -> x:acc) [] pipes

main = hspec $ do
    describe "putInBox" $ do
        it "Puts in box" $ do
            putInBox 10 [1, 2] [] `shouldBe` [1]
            putInBox 10 [10, 2] [] `shouldBe` [10]
            putInBox 10 [14, 2] [] `shouldBe` []
    describe "putInBox2" $ do
        it "Puts everything in box" $ do
            putInBox2 10 [1, 2] [] `shouldBe` [2, 1]
            putInBox2 10 [1, 2, 3] [] `shouldBe` [3, 2, 1]
            putInBox2 10 [1, 2, 3, 4] [] `shouldBe` [4, 3, 2, 1]
            putInBox2 10 [1, 2, 3, 4, 5] [] `shouldBe` [4, 3, 2, 1]
            putInBox2 10 [10, 2] [] `shouldBe` [10]
            putInBox2 10 [14, 2] [] `shouldBe` []
    describe "putInBox3" $ do
        it "Puts everything in box, and tell me what you couldn't put in" $ do
            putInBox3 10 [1, 2] [] `shouldBe` ([], [2, 1])
            putInBox3 10 [1, 2, 3] [] `shouldBe` ([], [3, 2, 1])
            putInBox3 10 [1, 2, 3, 4] [] `shouldBe` ([], [4, 3, 2, 1])
            putInBox3 10 [1, 2, 3, 4, 5] [] `shouldBe` ([5], [4, 3, 2, 1])
            putInBox3 10 [1, 2, 3, 4, 5, 2] [] `shouldBe` ([5, 2], [4, 3, 2, 1])
            putInBox3 10 [1, 2, 3, 4, 5, 2, 3] [] `shouldBe` ([5, 2, 3], [4, 3, 2, 1])
            --putInBox3 10 [3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3] [] `shouldBe` ([3, 3, 3], [3, 3, 3], [3, 3, 3], [3, 3, 3], [3, 3, 3], [3])
            putInBox3 10 [3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3] [] `shouldBe` ([3, 3, 3], [3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3])
            putInBox3 10 [10, 2] [] `shouldBe` ([2], [10])
            putInBox3 10 [14, 2] [] `shouldBe` ([14, 2], [])
--    describe "getBin" $ do
--        it "Grants bins" $ do
--            getBin 10 [10] `shouldBe` [[10]]
--            getBin 10 [5, 5] `shouldBe` [[5, 5]]
--            getBin 10 [6, 6] `shouldBe` [[6], [6]]
