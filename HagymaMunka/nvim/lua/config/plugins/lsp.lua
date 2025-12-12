return {
  -- Mason
  {
    'williamboman/mason.nvim',
    config = true,
  },

  -- Mason → LSP Install bridge
  {
    'williamboman/mason-lspconfig.nvim',
    dependencies = { 'williamboman/mason.nvim' },
    config = function()
      require('mason-lspconfig').setup({
        ensure_installed = {
          'lua_ls',
          'omnisharp',
          'clangd',
        },
      })
    end,
  },

  -- LSPconfig
  {
    'neovim/nvim-lspconfig',
    dependencies = {
      'williamboman/mason.nvim',
      'williamboman/mason-lspconfig.nvim',
      'saghen/blink.cmp',  -- Changed from cmp-nvim-lsp
    },
    config = function()
      -- Use blink.cmp capabilities instead
      local capabilities = require('blink.cmp').get_lsp_capabilities()

      local on_attach = function(client, bufnr)
        local opts = { buffer = bufnr }
        vim.keymap.set('n', 'gd', vim.lsp.buf.definition, opts)
        vim.keymap.set('n', 'K', vim.lsp.buf.hover, opts)
        vim.keymap.set('n', 'gr', vim.lsp.buf.references, opts)
        vim.keymap.set('n', '<leader>rn', vim.lsp.buf.rename, opts)
        vim.keymap.set('n', '<leader>ca', vim.lsp.buf.code_action, opts)

        if client.name == 'clangd' then
          vim.keymap.set('n', '<leader>h', '<cmd>ClangdSwitchSourceHeader<cr>', opts)
        end
      end

      local default_config = {
        capabilities = capabilities,
        on_attach = on_attach,
      }

      -- Lua Language Server
      vim.lsp.enable('lua_ls', vim.tbl_extend("force", default_config, {
        settings = {
          Lua = {
            diagnostics = { globals = { "vim" } },
          },
        },
      }))

      -- Clangd
      vim.lsp.enable('clangd', vim.tbl_extend("force", default_config, {
        cmd = {
          'clangd',
          '--background-index',
          '--clang-tidy',
          '--header-insertion=iwyu',
          '--completion-style=detailed',
          '--function-arg-placeholders',
        },
      }))

      -- OmniSharp
      vim.lsp.enable('omnisharp', default_config)
    end,
  },
}