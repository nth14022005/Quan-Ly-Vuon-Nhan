using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLVuonNhan
{
    public static class DgvSearch
    {
        /// <summary>
        /// Lọc DataGridView theo keyword. 
        /// - Nếu truyền columnNames thì chỉ search các cột đó.
        /// - Không truyền thì search tất cả cột đang Visible.
        /// </summary>
        public static void Apply(DataGridView dgv, string keyword, params string[] columnNames)
        {
            if (dgv == null) return;

            keyword = (keyword ?? "").Trim();
            string kwLower = keyword.ToLowerInvariant();

            // chọn cột để search
            List<int> colIndexes = new List<int>();

            if (columnNames != null && columnNames.Length > 0)
            {
                foreach (var name in columnNames)
                {
                    var col = dgv.Columns.Cast<DataGridViewColumn>()
                                .FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
                    if (col != null) colIndexes.Add(col.Index);
                }
            }
            else
            {
                foreach (DataGridViewColumn c in dgv.Columns)
                    if (c.Visible) colIndexes.Add(c.Index);
            }

            // Tránh lỗi "Row associated with the currency manager cannot be made invisible"
            CurrencyManager cm = null;
            try
            {
                if (dgv.DataSource != null)
                    cm = dgv.BindingContext[dgv.DataSource] as CurrencyManager;

                cm?.SuspendBinding();
            }
            catch { /* ignore */ }

            try
            {
                dgv.CurrentCell = null; // tránh đang đứng ở row sẽ bị ẩn

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    bool match = string.IsNullOrEmpty(kwLower);

                    if (!match)
                    {
                        foreach (int i in colIndexes)
                        {
                            var cell = row.Cells[i];
                            var text = cell?.Value?.ToString();
                            if (!string.IsNullOrEmpty(text) && text.ToLowerInvariant().Contains(kwLower))
                            {
                                match = true;
                                break;
                            }
                        }
                    }

                    row.Visible = match;
                }
            }
            finally
            {
                try { cm?.ResumeBinding(); } catch { }
            }
        }
    }
}
