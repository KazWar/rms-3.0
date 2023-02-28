<script setup lang=ts>
    import { Field, FieldDTO } from '@/common'
    import { FormKitFrameworkContext } from '@formkit/core'
    import { QOptionGroup, QOptionGroupProps } from 'quasar';
    import { ref } from 'vue'
    
    const { context } = defineProps<{
    context: FormKitFrameworkContext
}>()

const { 
     label, value
 } = context.field as Field

</script>

<template>
    <div>
        <span v-html="value"></span>
    </div>
</template>

<style lang="scss" scoped>

</style>