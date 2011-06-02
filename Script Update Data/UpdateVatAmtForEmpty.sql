----- update by Calculate
--select
--    [advpclosed_clearvatbasenotdue]
--  , [advpclosed_clearvatamtnotdue] = [advpclosed_clearvatbasenotdue] * 0.07
update [AdvancePayClosed]  
--from
    --[AdvancePayClosed]
set [advpclosed_clearvatamtnotdue] = round([advpclosed_clearvatbasenotdue] * 0.07,2)
where
    [advpclosed_clearvatamtnotdue] is null

--select
--    [paysi_amt]
--  , paysi_vatamt = round(paysi_amt * 0.07,2)
--from
update    [apvatinputitem]
set paysi_vatamt = round(paysi_amt * 0.07,2)
where
    [paysi_vatamt] is null

--select
--    receivesi_amt
--  , receivesi_vatamt = [stock_taxBase] * 0.07
--from
update
    [receiveselectionitem]
    set receivesi_vatamt = round([stock_taxBase] * 0.07,2)
where
    [receivesi_vatamt] is null
    and [receivesi_amt] / [receivesi_billedamt] = 1

--select
--    paysi_amt
--  , [paysi_vatamt] = round(stock_taxbase * 0.07, 2)
--  , *
--from
update 
    [payselectionitem]
set [paysi_vatamt] = round(stock_taxbase * 0.07, 2)
where
    paysi_vatamt is null
    and [paysi_amt] / [paysi_billedamt] = 1


------- update Calc ไม่ได้
--select
--    receivesi_amt
--  , receivesi_vatamt = round([receivesi_amt] / [receivesi_billedamt]
--                             * stock_taxbase * 0.07, 2)
--  , *
--from
update
    [receiveselectionitem]
    set receivesi_vatamt = round([receivesi_amt] / [receivesi_billedamt] * stock_taxbase * 0.07, 2)
where
    [receivesi_vatamt] is null
    and [receivesi_amt] / [receivesi_billedamt] <> 1


--select
--    paysi_amt
--  , [paysi_vatamt] = round([paysi_amt] / [paysi_billedamt] * stock_taxbase
--                           * 0.07, 2)
--  , *
--from
update
    [payselectionitem]
set [paysi_vatamt] = round([paysi_amt] / [paysi_billedamt] * stock_taxbase * 0.07, 2)
where
    paysi_vatamt is null
    and [paysi_amt] / [paysi_billedamt] <> 1
    and stock_type <> 199
    and [paysi_unpaidamt] <> 0
    and [paysi_billedamt] <> 0
