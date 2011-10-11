select gl_status ,gli_status,* from glitem
left join gl on [glitem].[gli_gl] = [gl].[gl_id] 
 where gli_status <> gl_status
 
 update [glitem]
 set gli_status = gl_status
 from glitem
left join gl on [glitem].[gli_gl] = [gl].[gl_id] 
 where gli_status <> gl_status