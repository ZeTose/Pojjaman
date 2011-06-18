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
    
-- แก้ bill amt ให้เอายอดเอกสารตลอด
update [payselectionitem]
set paysi_billedamt = payment_amt 
from [payselectionitem] left join 
(
select payment_refdoc,payment_refdoctype,payment_amt,payment_gross from [payment]
union all
select receive_refdoc,receive_refdoctype,receive_amt,receive_gross from [receive]

) pay on stock_id = payment_refdoc and stock_type = payment_refdoctype
where [paysi_billedamt] <> payment_amt 
-----
--select
--    receivesi_amt
--  , receivesi_vatamt = [stock_taxBase] * 0.07
--from
update
    [receiveselectionitem]
    set receivesi_vatamt = round([stock_taxBase] * 0.07,2)
from [receiveselectionitem]
 left join vat on vat_refdoc = receivesi_receives and vat_refdoctype = 82
where vat_taxbase <> 0
and
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
,[paysi_dueVatBase] = stock_taxbase
from [payselectionitem]
 left join vat on vat_refdoc = paysi_pays and vat_refdoctype = 73
where vat_taxbase <> 0
and
    paysi_vatamt is null
    and
     [paysi_amt] / [paysi_billedamt] = 1
     and [paysi_billedamt] <> 0


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
from [receiveselectionitem]
 left join vat on vat_refdoc = receivesi_receives and vat_refdoctype = 82
where vat_taxbase <> 0
and
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
,[paysi_dueVatBase] = round([paysi_amt] / [paysi_billedamt] * stock_taxbase , 2)
from [payselectionitem]
 left join vat on vat_refdoc = paysi_pays and vat_refdoctype = 73
where vat_taxbase <> 0
and
    paysi_vatamt is null 
    and [paysi_amt] / [paysi_billedamt] <> 1
    and stock_type <> 199
    and [paysi_unpaidamt] <> 0
    and [paysi_billedamt] <> 0
