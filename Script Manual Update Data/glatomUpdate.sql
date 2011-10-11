--insert into [entityautogen]
--        ( [entity_id]
--        ,[entity_autocodeFormat]
--        ,[entityauto_glf]
--        ,[entityauto_desc]
--        ,[entityauto_config]
--        )
--values
--        ( 440, -- entity_id - numeric
--         'Cost-"CC"-###', -- entity_autocodeFormat - nvarchar(200)
--         null , -- entityauto_glf - numeric
--         null , -- entityauto_desc - nvarchar(400)
--         null  -- entityauto_config - numeric
--        )


------ update filed in glformatitem
--update [GLFormatItem]  
--set glfi_field = d.glfi_field
--from
----select gi.[glfi_mapping],gi.[glfi_field],d.[glfi_mapping],d.[glfi_field],gi.*,d.* from
-- [DefaultGLFormatItem] d
--left join [GLFormat] g on d.[glfi_linkgl] = g.[glf_linkgl]
--left join [GLFormatItem] gi on [g].[glf_id] = gi.[glfi_glf] and d.[glfi_mapping] = gi.[glfi_mapping]  
--where d.[glfi_field] <> gi.[glfi_field] 


 
 

 
 
 
 
 