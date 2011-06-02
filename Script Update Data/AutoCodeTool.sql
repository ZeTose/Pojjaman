declare @count numeric

select @count = count(*) from [entityautogen] where [entity_id] = 345

if @count =0 
begin
insert into [entityautogen]
        ( [entity_id]
        ,[entity_autocodeFormat]
        ,[entityauto_glf]
        ,[entityauto_desc]
        ,[entityauto_config]
        )
values
        ( 345
        , -- entity_id - numeric
         'EW-"YY"####'
        , -- entity_autocodeFormat - nvarchar(200)
         null
        , -- entityauto_glf - numeric
         null
        , -- entityauto_desc - nvarchar(400)
         null  -- entityauto_config - numeric
        )

end


select @count = count(*) from [entityautogen] where [entity_id] = 351

if @count =0 
begin
insert into [entityautogen]
        ( [entity_id]
        ,[entity_autocodeFormat]
        ,[entityauto_glf]
        ,[entityauto_desc]
        ,[entityauto_config]
        )
values
        ( 351
        , -- entity_id - numeric
         'ER-"YY"####'
        , -- entity_autocodeFormat - nvarchar(200)
         null
        , -- entityauto_glf - numeric
         null
        , -- entityauto_desc - nvarchar(400)
         null  -- entityauto_config - numeric
        )

end


select @count = count(*) from [entityautogen] where [entity_id] = 354

if @count =0 
begin
insert into [entityautogen]
        ( [entity_id]
        ,[entity_autocodeFormat]
        ,[entityauto_glf]
        ,[entityauto_desc]
        ,[entityauto_config]
        )
values
        ( 354
        , -- entity_id - numeric
         'EC-"YY"####'
        , -- entity_autocodeFormat - nvarchar(200)
         null
        , -- entityauto_glf - numeric
         null
        , -- entityauto_desc - nvarchar(400)
         null  -- entityauto_config - numeric
        )

end



select @count = count(*) from [entityautogen] where [entity_id] = 348

if @count =0 
begin
insert into [entityautogen]
        ( [entity_id]
        ,[entity_autocodeFormat]
        ,[entityauto_glf]
        ,[entityauto_desc]
        ,[entityauto_config]
        )
values
        ( 348
        , -- entity_id - numeric
         '"PAR"-####'
        , -- entity_autocodeFormat - nvarchar(200)
         null
        , -- entityauto_glf - numeric
         null
        , -- entityauto_desc - nvarchar(400)
         null  -- entityauto_config - numeric
        )

end



