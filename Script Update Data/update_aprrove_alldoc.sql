--สร้าง Data สำหรับหน้า MultiApprove
insert  into dbo.DocForMultiApproval (doca_entityid, doca_entitytype, doca_code, doca_docdate, doca_amount, doca_editor, doca_method, doca_editdate, doca_comment, doca_cc, doca_supplier)
        select [id], [type], [code], [docdate], [gross], [commentetor], [method], [editedate], [comment], [cc], [supplier]
        from  ( select pr_id [id], 7 [type], pr_code [code], pr_docDate [docdate], pr_gross [gross], isnull(isnull(commentator,pr_lasteditor),  pr_originator) [commentetor]
                          , case when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 1 then 0
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) > 0 then 4
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) = 0 then 3
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(pr_lasteditor,0) = 0 then 1
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(pr_lasteditor,0) > 0 then 2
                            end [method]
                          , isnull(isnull(commentDate,pr_lasteditdate),
                                   pr_origindate) [editedate]
                          , apvdoc_comment [comment]
                          , pr_cc [cc]
                          , null [supplier]
                  from      pr
                            left join ( select  *
                                        from    LastApproveView
                                        where   apvdoc_entityType = 7
                                      ) [ls] on pr_id = apvdoc_entityId
                  where     isnull(pr_approveperson,0) = 0
                  union
                  select    po_id
                          , 6
                          , po_code
                          , po_docDate
                          , po_aftertax
                          , isnull(isnull(commentator,po_lasteditor),
                                   po_originator)
                          , case when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 1 then 0
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) > 0 then 4
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) = 0 then 3
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(po_lasteditor,0) = 0 then 1
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(po_lasteditor,0) > 0 then 2
                            end [method]
                          , isnull(isnull(commentDate,po_lasteditdate),
                                   po_origindate)
                          , apvdoc_comment
                          , po_cc
                          , po_supplier
                  from      po
                            left join ( select  *
                                        from    LastApproveView
                                        where   apvdoc_entityType = 6
                                      ) [ls] on po_id = apvdoc_entityId
                  where     isnull(po_approveperson,0) = 0
                  union
                  select    stock_id
                          , 45
                          , stock_code
                          , stock_docDate
                          , stock_aftertax
                          , isnull(isnull(commentator,stock_lasteditor),
                                   stock_originator)
                          , case when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 1 then 0
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) > 0 then 4
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) = 0 then 3
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(stock_lasteditor,0) = 0
                                 then 1
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(stock_lasteditor,0) > 0
                                 then 2
                            end [method]
                          , isnull(isnull(commentDate,stock_lasteditdate),
                                   stock_origindate)
                          , apvdoc_comment
                          , stock_tocc
                          , stock_entity
                  from      stock
                            left join ( select  *
                                        from    LastApproveView
                                        where   apvdoc_entityType = 45
                                      ) [ls] on stock_id = apvdoc_entityId
                  where     isnull(stock_approveperson,0) = 0
                            and stock_type = 45
                  union
                  select    wr_id
                          , 324
                          , wr_code
                          , wr_docDate
                          , wr_gross
                          , isnull(isnull(commentator,wr_lasteditor),
                                   wr_originator)
                          , case when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 1 then 0
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) > 0 then 4
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) = 0 then 3
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(wr_lasteditor,0) = 0 then 1
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(wr_lasteditor,0) > 0 then 2
                            end [method]
                          , isnull(isnull(commentDate,wr_lasteditdate),
                                   wr_origindate)
                          , apvdoc_comment
                          , wr_cc
                          , null wr_subcontractor
                  from      wr
                            left join ( select  *
                                        from    LastApproveView
                                        where   apvdoc_entityType = 324
                                      ) [ls] on wr_id = apvdoc_entityId
                  where     isnull(wr_approveperson,0) = 0
                  union
                  select    sc_id
                          , 289
                          , sc_code
                          , sc_docDate
                          , sc_aftertax
                          , isnull(isnull(commentator,sc_lasteditor),
                                   sc_originator)
                          , case when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 1 then 0
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) > 0 then 4
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) = 0 then 3
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(sc_lasteditor,0) = 0 then 1
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(sc_lasteditor,0) > 0 then 2
                            end [method]
                          , isnull(isnull(commentDate,sc_lasteditdate),
                                   sc_origindate)
                          , apvdoc_comment
                          , sc_cc
                          , sc_subcontractor
                  from      sc
                            left join ( select  *
                                        from    LastApproveView
                                        where   apvdoc_entityType = 289
                                      ) [ls] on sc_id = apvdoc_entityId
                  where     isnull(sc_approveperson,0) = 0
                  union
                  select    vo_id
                          , 290
                          , vo_code
                          , vo_docDate
                          , vo_aftertax
                          , isnull(isnull(commentator,vo_lasteditor),
                                   vo_originator)
                          , case when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 1 then 0
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) > 0 then 4
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) = 0 then 3
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(vo_lasteditor,0) = 0 then 1
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(vo_lasteditor,0) > 0 then 2
                            end [method]
                          , isnull(isnull(commentDate,vo_lasteditdate),
                                   vo_origindate)
                          , apvdoc_comment
                          , vo_cc
                          , vo_subcontractor
                  from      vo
                            left join ( select  *
                                        from    LastApproveView
                                        where   apvdoc_entityType = 290
                                      ) [ls] on vo_id = apvdoc_entityId
                  where     isnull(vo_approveperson,0) = 0
                  union
                  select    dr_id
                          , 291
                          , dr_code
                          , dr_docDate
                          , dr_aftertax
                          , isnull(isnull(commentator,dr_lasteditor),
                                   dr_originator)
                          , case when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 1 then 0
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) > 0 then 4
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) = 0 then 3
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(dr_lasteditor,0) = 0 then 1
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(dr_lasteditor,0) > 0 then 2
                            end [method]
                          , isnull(isnull(commentDate,dr_lasteditdate),
                                   dr_origindate)
                          , apvdoc_comment
                          , null dr_cc
                          , dr_subcontractor
                  from      dr
                            left join ( select  *
                                        from    LastApproveView
                                        where   apvdoc_entityType = 291
                                      ) [ls] on dr_id = apvdoc_entityId
                  where     isnull(dr_approveperson,0) = 0
                  union
                  select    pa_id
                          , 292
                          , pa_code
                          , pa_docDate
                          , pa_aftertax
                          , isnull(isnull(commentator,pa_lasteditor),
                                   pa_originator)
                          , case when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 1 then 0
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) > 0 then 4
                                 when isnull(apvdoc_entityid,0) > 0
                                      and isnull(apvdoc_reject,0) = 0
                                      and isnull(apvdoc_level,0) = 0 then 3
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(pa_lasteditor,0) = 0 then 1
                                 when isnull(apvdoc_entityid,0) = 0
                                      and isnull(pa_lasteditor,0) > 0 then 2
                            end [method]
                          , isnull(isnull(commentDate,pa_lasteditdate),
                                   pa_origindate)
                          , apvdoc_comment
                          , null pa_cc
                          , pa_subcontractor
                  from      pa
                            left join ( select  *
                                        from    LastApproveView
                                        where   apvdoc_entityType = 292
                                      ) [ls] on pa_id = apvdoc_entityId
                  where     isnull(pa_approveperson,0) = 0
                ) [doc]
                left join DocForMultiApproval on id = doca_entityid
                                                 and type = doca_entitytype
        where   doca_entityid is null

update  dbo.DocForMultiApproval set doca_comment = apvdoc_comment, doca_approveid = commentator, doca_approvdate = commentDate, doca_approvelevel = apvdoc_level
from    dbo.DocForMultiApproval
        inner join ( select * From LastApproveView  where  isnull(apvdoc_level,0) <> 0 and isnull(apvdoc_reject,0) <> 1) [apv] on doca_entityid = apvdoc_entityId and doca_entitytype = apvdoc_entitytype
                   
                              
--select * from LastApproveView where apvdoc_entityType = 7

--select * from dbo.CodeDescription where code_name like '%docApproveMethod%'

--select * from DocForMultiApproval where doca_method in (4,5)

--update dbo.DocForMultiApproval set doca_method = 5
--where doca_method = 4 and doca_approveid is not null


--select * from sysobjects where name like '%approv%' and xtype = 'v'

--sp_helptext LastRightApproveView

----edited : 2010-11-05 by julawut  
--CREATE View LastRightApproveView  
--as   
----left join (   
--select  [app].apvdoc_entityId [last_apvdoc_entityId],  
--        [app].apvdoc_entityType [last_apvdoc_entityType],  
--        --[app].apvdoc_comment [last_apvdoc_comment],  
--        [app].apvdoc_level [last_apvdoc_level]  
--        --[app].apvdoc_linenumber [last_apvdoc_linenumber],  
--        --isnull(dbo.iscase([app].apvdoc_lastEditor, 0, null),  
--        --       dbo.iscase([app].apvdoc_originator, 0, null)) [commentator],  
--        --isnull([app].apvdoc_lastEditDate,  
--        --       [app].apvdoc_originDate) [commentDate],  
--        --[app].apvdoc_reject  
--from    dbo.ApproveDoc [app]  
--        inner join ( select apvdoc_entityId,  
--                            apvdoc_entityType,  
--                            max(apvdoc_linenumber) [apvdoc_linenumber]  
--                     from   dbo.ApproveDoc  
--                     where  apvdoc_level <> 0  
--                     group by apvdoc_entityId,  
--                            apvdoc_entityType  
--                   ) [appchild] on [app].apvdoc_entityId = [appchild].apvdoc_entityId  
--                                   and [app].apvdoc_entityType = [appchild].apvdoc_entityType  
--                                   and [app].apvdoc_linenumber = [appchild].apvdoc_linenumber  
--where isnull([app].apvdoc_reject,0) <> 1                                     
----) [appDocComment] on docid = apvdoc_entityId  
----                     and doctype = apvdoc_entityType    