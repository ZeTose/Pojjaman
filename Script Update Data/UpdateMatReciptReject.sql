-- แก้ bug ถ้าไม่ approve ก็ reject
update [StockiApprovalStoreComment]
set [apvstore_approveType] = -1
where [apvstore_approveType] <> 1