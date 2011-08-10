--ย้าย Reference ของการจัดสรร ไปไว้ใน table wbsreference
insert  into wbsreference (wbs_id, wbs_ismarkup, refto_id, refto_type, refto_iscanceled)
        select distinct wbsid, ismarkup, reftoid, reftotype, iscanceled
        from    (
	--PR--
                  select    priw_wbs wbsid
                          , priw_isMarkup ismarkup
                          , priw_pr reftoid
                          , 7 reftotype
                          , case pr_status
                              when 0 then 1
                              else 0
                            end iscanceled
                  from      priwbs
                            inner join pr on priw_pr = pr_id
                  union --PO--
                  select    poiw_wbs
                          , poiw_isMarkup
                          , poiw_po
                          , 6
                          , case po_status
                              when 0 then 1
                              else 0
                            end
                  from      poiwbs
                            inner join po on poiw_po = po_id
                  union --GR--MAT--
                  select    stockiw_wbs
                          , stockiw_isMarkup
                          , stocki_stock
                          , stock_type
                          , case stock_status
                              when 0 then 1
                              else 0
                            end
                  from      stockiwbs
                            inner join dbo.stockitem on dbo.stockiwbs.stockiw_sequence = dbo.stockitem.stocki_sequence
                            inner join stock on dbo.stockitem.stocki_stock = dbo.stock.stock_id
                  union --WR--	
                  select    driw_wbs
                          , driw_isMarkup
                          , dri_dr
                          , 291
                          , case dr_status
                              when 0 then 1
                              else 0
                            end
                  from      driwbs
                            inner join dbo.dritem on dbo.driwbs.driw_sequence = dbo.dritem.dri_sequence
                            inner join dr on dbo.dritem.dri_dr = dbo.dr.dr_id
                  union --PA--
                  select    paiw_wbs
                          , paiw_isMarkup
                          , pai_pa
                          , 292
                          , case pa_status
                              when 0 then 1
                              else 0
                            end
                  from      paiwbs
                            inner join dbo.paitem on dbo.paiwbs.paiw_sequence = dbo.paitem.pai_sequence
                            inner join pa on dbo.paitem.pai_pa = dbo.pa.pa_id
                  union --SC--
                  select    sciw_wbs
                          , sciw_isMarkup
                          , sci_sc
                          , 289
                          , case sc_status
                              when 0 then 1
                              else 0
                            end
                  from      sciwbs
                            inner join dbo.scitem on dbo.sciwbs.sciw_sequence = dbo.scitem.sci_sequence
                            inner join sc on dbo.scitem.sci_sc = dbo.sc.sc_id
                  union --VO--
                  select    sciw_wbs
                          , sciw_isMarkup
                          , sci_sc
                          , 290
                          , case sc_status
                              when 0 then 1
                              else 0
                            end
                  from      sciwbs
                            inner join dbo.scitem on dbo.sciwbs.sciw_sequence = dbo.scitem.sci_sequence
                            inner join sc on dbo.scitem.sci_sc = dbo.sc.sc_id
                  union --WR--
                  select    wriw_wbs
                          , wriw_isMarkup
                          , wri_wr
                          , 324
                          , case wr_status
                              when 0 then 1
                              else 0
                            end
                  from      wriwbs
                            inner join dbo.writem on dbo.wriwbs.wriw_sequence = dbo.writem.wri_sequence
                            inner join wr on dbo.writem.wri_wr = dbo.wr.wr_id
                  union --EQT--
                  select    eqtstockiw_wbs
                          , eqtstockiw_isMarkup
                          , eqtstocki_eqtstock
                          , eqtstock_type
                          , case eqtstock_docstatus
                              when 0 then 1
                              else 0
                            end
                  from      eqtstockiwbs
                            inner join dbo.eqtstockitem on dbo.eqtstockiwbs.eqtstockiw_sequence = dbo.eqtstockitem.eqtstocki_sequence
                            inner join eqtstock on dbo.eqtstockitem.eqtstocki_eqtstock = dbo.eqtstock.eqtstock_id
                ) ref
                left join dbo.wbsreference on wbsid = wbs_id
                                              and ismarkup = wbs_ismarkup
                                              and reftoid = refto_id
                                              and reftotype = refto_type
        where   wbs_id is null
                and isnull(wbsid,0) > 0

--ล้าง reference เดิมของ wbs ออก
delete from dbo.reference where entity_id = 0 or entity_type = 216